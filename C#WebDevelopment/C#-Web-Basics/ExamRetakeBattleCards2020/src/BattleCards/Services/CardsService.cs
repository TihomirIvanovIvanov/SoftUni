using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext dbContext;

        public CardsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(AddCardInputModel input)
        {
            var card = new Card
            {
                ImageUrl = input.Image,
                Name = input.Name,
                Description = input.Description,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
            };

            this.dbContext.Cards.Add(card);
            this.dbContext.SaveChanges();
        }

        public IQueryable<AllCardsViewModel> GetAll()
        {
            var viewModel = this.dbContext.Cards
                .Select(card => new AllCardsViewModel
                {
                    Id = card.Id,
                    ImageUrl = card.ImageUrl,
                    Description = card.Description,
                    Name = card.Name,
                    Keyword = card.Keyword,
                    Attack = card.Attack,
                    Health = card.Health,
                });

            return viewModel;
        }

        public IQueryable<CardsCollectionViewModel> GetMyCardsCollection(string userId)
        {
            var viewModel = this.dbContext.UserCards
                .Where(user => user.UserId == userId)
                .Select(card => new CardsCollectionViewModel
                {
                    Id = card.Card.Id,
                    Name = card.Card.Name,
                    Description = card.Card.Description,
                    Keyword = card.Card.Keyword,
                    Attack = card.Card.Attack,
                    Health = card.Card.Health,
                    ImageUrl = card.Card.ImageUrl,
                });

            return viewModel;
        }
    }
}
