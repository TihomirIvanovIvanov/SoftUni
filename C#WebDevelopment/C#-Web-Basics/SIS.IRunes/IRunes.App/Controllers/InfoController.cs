namespace IRunes.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using ViewModels;

    public class InfoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Index(TestCreateModel testCreateModel)
        {
            testCreateModel.Selections.ForEach(System.Console.WriteLine);

            return this.View();
        }
    }
}
