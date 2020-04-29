﻿using BattleCards.ViewModels.Cards;
using System.Linq;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        IQueryable<AllCardsViewModel> GetAll();

        void Add(AddCardInputModel input);
    }
}
