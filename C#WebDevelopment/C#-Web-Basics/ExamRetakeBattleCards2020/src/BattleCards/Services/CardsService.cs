using BattleCards.Data;
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
    }
}
