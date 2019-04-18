using SIS.Framework.Controllers;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHttpHandler
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();

            if (request.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Url.Split('/', StringSplitOptions.RemoveEmptyEntries);

                controllerName = requestUrlSplit[0];
                actionName = requestUrlSplit[1];
            }

            var controller = this.GetController(controllerName, request);

            return null;
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (string.IsNullOrWhiteSpace(controllerName))
            {
                return null;
            }

            var fullyQualifiedControllerName = string.Format("{0}.{1}.{2}{3}, {4}",
                MvcContext.Get.AssemblyName.Name, MvcContext.Get.ControllersFolder, controllerName, MvcContext.Get.ControllerSuffix, MvcContext.Get.AssemblyName);

            var controllerType = Type.GetType(fullyQualifiedControllerName);
            var conroller = (Controller)Activator.CreateInstance(controllerType);
            return conroller;
        }
    }
}
