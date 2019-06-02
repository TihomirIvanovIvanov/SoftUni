namespace SIS.MvcFramework.Result
{
    using HTTP.Common;
    using HTTP.Enums;
    using HTTP.Headers;

    public class RedirectResult : ActionResult
    {
        public RedirectResult(string location) : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new HttpHeader(GlobalConstants.Location, location));
        }
    }
}
