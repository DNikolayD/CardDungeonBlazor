using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controls
{
    public class CardsControler
    {
        private readonly ApplicationDbContext data;

        public CardsControler(ApplicationDbContext data)
            => this.data = data;

        public IActionResult Add(AddCardFormModel card)
        {

            var cardData = new Card
            {
                Name = card.Name,
                CardTypeId = card.CardTypeId,
                Description = card.Description,
                Value = card.Value,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                IsEdited = false,

            };
            this.data.Cards.Add(cardData);
            this.data.SaveChanges();     
            return null;
        }

        public List<CardTypeViewModel> GetCardTypeViewModels(ApplicationDbContext data)
        {
            List<CardTypeViewModel> cardTypeViewModel = new();
            foreach (var cardType in data.CardTypes)
            {
                cardTypeViewModel.Add(new CardTypeViewModel
                {
                    Id = cardType.Id,
                    Name = cardType.Name
                });
            }
            return cardTypeViewModel;
        }
    }
}
