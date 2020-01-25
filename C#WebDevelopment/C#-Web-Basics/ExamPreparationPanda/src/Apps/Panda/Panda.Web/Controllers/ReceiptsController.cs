using Panda.Services;
using Panda.Web.ViewModels.Receipts;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;

namespace Panda.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = this.receiptsService.GetAll()
                .Select(receipt => new ReceiptViewModel
                {
                    Id = receipt.Id,
                    Fee = receipt.Fee,
                    IssuedOn = receipt.IssuedOn,
                    RecipientName = receipt.Recipient.Username
                }).ToList();

            return this.View(viewModel);
        }
    }
}
