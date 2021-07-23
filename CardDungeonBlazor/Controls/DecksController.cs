using CardDungeonBlazor.Data;
using CardDungeonBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controls
{
    public class DecksController
    {
        private readonly ApplicationDbContext data;

        public DecksController(ApplicationDbContext data)
           => this.data = data;

        public IActionResult Add(AddCardsToDeckModel card)
        {

           /* var cardData = new 
            {
              /*  Name = card.Name,
                ImageUrl = card.ImageUrl,
                CardTypeId = card.CardTypeId,
                Description = card.Description,
                Value = card.Value,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                IsEdited = false, 

            };
            this.data.Cards.Add(cardData);
            this.data.SaveChanges(); */
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

        public AllCardsViewModel GetAllCards(ApplicationDbContext data)
        {
            AllCardsViewModel allCards = new();
            foreach (var card in data.Cards)
            {
                allCards.Cards.Add(new CardServiceModel
                {
                    Id = card.Id,
                    CardType = data.CardTypes.FirstOrDefault(x => x.Id == card.CardTypeId).Name,
                    Name = card.Name,
                    ImageUrl = card.ImageUrl,
                    Value = card.Value,
                });
            }
            return allCards;
        }
    }
}
