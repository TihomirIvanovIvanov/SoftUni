namespace SIS.MvcFramework
{
    using Attributes.Action;
    using Attributes.Http;
    using Attributes.Security;
    using DependencyContainer;
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Responses;
    using Logging;
    using Result;
    using Routing;
    using Sessions;
    using SIS.HTTP.Requests;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class WebHost
    {
        public static void Start(IMvcApplication application)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            IHttpSessionStorage httpSessionStorage = new HttpSessionStorage();
            IServiceProvider serviceProvider = new ServiceProvider();
            serviceProvider.Add<ILogger, ConsoleLogger>();

            application.ConfigureServices(serviceProvider);

            AutoRegisterRoutes(application, serverRoutingTable, serviceProvider);
            application.Configure(serverRoutingTable);
            Server server = new Server(8000, serverRoutingTable, httpSessionStorage);
            server.Run();
        }

        private static void AutoRegisterRoutes(
            IMvcApplication application, IServerRoutingTable serverRoutingTable, IServiceProvider serviceProvider)
        {
            var controllers = application.GetType().Assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && typeof(Controller).IsAssignableFrom(type));

            foreach (var controllerType in controllers)
            {
                var actions = controllerType.GetMethods(BindingFlags.DeclaredOnly
                    | BindingFlags.Public
                    | BindingFlags.Instance)
                    .Where(type => !type.IsSpecialName && type.DeclaringType == controllerType)
                    .Where(action => action.GetCustomAttributes().All(a => a.GetType() != typeof(NonActionAttribute)));

                foreach (var action in actions)
                {
                    var path = $"/{controllerType.Name.Replace(GlobalConstants.Controller, string.Empty)}/{action.Name}";

                    var attribute = action
                        .GetCustomAttributes()
                        .Where(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute))).LastOrDefault() as BaseHttpAttribute;

                    var httpMethod = HttpRequestMethod.Get;

                    if (attribute != null)
                    {
                        httpMethod = attribute.Method;
                    }

                    if (attribute?.Url != null)
                    {
                        path = attribute.Url;
                    }

                    if (attribute?.ActionName != null)
                    {
                        path = $"/{controllerType.Name.Replace(GlobalConstants.Controller, string.Empty)}/{attribute.ActionName}";
                    }

                    serverRoutingTable.Add(httpMethod, path,
                        (request) => ProcessRequest(serviceProvider, controllerType, action, request));

                    System.Console.WriteLine(httpMethod + " " + path);
                }
            }
        }

        private static IHttpResponse ProcessRequest(
            IServiceProvider serviceProvider, System.Type controllerType, MethodInfo action, IHttpRequest httpRequest)
        {
            var controllerInstance = serviceProvider.CreateInstance(controllerType) as Controller;
            controllerInstance.Request = httpRequest;

            // Security Authorization - TODO: Refactor this
            var controllerPrincipal = controllerInstance.User;
            var authorizeAttribute = action
                .GetCustomAttributes().LastOrDefault(a => a.GetType() == typeof(AuthorizeAttribute)) as AuthorizeAttribute;

            if (authorizeAttribute != null && !authorizeAttribute.IsInAuthority(controllerPrincipal))
            {
                // TODO: Redirect to configure URL
                return new HttpResponse(HttpResponseStatusCode.Forbidden);
            }

            var parameters = action.GetParameters();
            var parameterValues = new List<object>();

            foreach (var parameter in parameters)
            {
                var parameterName = parameter.Name.ToLower();
                //ISet<string> httpDataValue = null;

                //if (httpRequest.QueryData.Any(elem => elem.Key.ToLower() == parameterName))
                //{
                //    httpDataValue = httpRequest.QueryData.FirstOrDefault(elem => elem.Key.ToLower() == parameterName);
                //}

                //if (httpRequest.FormData.Any(elem => elem.Key.ToLower() == parameterName))
                //{
                //    httpDataValue = httpRequest.FormData.FirstOrDefault(elem => elem.Key.ToLower() == parameterName);
                //}


                //System.Convert.ChangeType()
            }

            var response = action.Invoke(controllerInstance, parameterValues.ToArray()) as ActionResult;
            return response;
        }
    }
}
