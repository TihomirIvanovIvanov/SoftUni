namespace SIS.MvcFramework.Result
{
    using HTTP.Enums;
    using System.Text;

    public class NotFoundResult : ActionResult 
    {
        public NotFoundResult(string message, HttpResponseStatusCode httpResponseStatusCode = HttpResponseStatusCode.NotFound)
            : base(httpResponseStatusCode)
        {
            this.Content = Encoding.UTF8.GetBytes(message);
        }
    }
}
