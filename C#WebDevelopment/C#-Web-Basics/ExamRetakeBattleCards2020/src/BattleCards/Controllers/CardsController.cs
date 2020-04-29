using BattleCards.Services;
using BattleCards.ViewModels.Cards;
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

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 5 || input.Name.Length > 15)
            {
                return this.Add();
            }

            if (string.IsNullOrWhiteSpace(input.Image))
            {
                return this.Add();
            }

            if (string.IsNullOrWhiteSpace(input.Keyword))
            {
                return this.Add();
            }

            if (input.Attack <= 0)
            {
                return this.Add();
            }

            if (input.Health <= 0)
            {
                return this.Add();
            }

            if (input.Description.Length > 200)
            {
                return this.Add();
            }

            this.cardsService.Add(input);
            return this.All();
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var myCollectionViewModel = this.cardsService.GetMyCardsCollection(this.User).ToArray();
            return this.View(myCollectionViewModel);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.cardsService.AddCardToCollection(cardId, this.User);
            return this.All();
        }
    }
}
