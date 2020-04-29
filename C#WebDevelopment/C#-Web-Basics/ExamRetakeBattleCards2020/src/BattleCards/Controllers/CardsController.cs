using BattleCards.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Linq;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allCardsView = this.cardsService.GetAll().ToArray();
            return this.View(allCardsView);
        }
    }
}
