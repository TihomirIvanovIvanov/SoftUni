using Panda.Services;
using SIS.MvcFramework;

namespace Panda.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceipstService receipstService;

        public ReceiptsController(IReceipstService receipstService)
        {
            this.receipstService = receipstService;
        }
    }
}
