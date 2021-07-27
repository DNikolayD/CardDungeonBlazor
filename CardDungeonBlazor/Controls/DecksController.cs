using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.Common;
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

        public IActionResult Add(AddDeckFormModel deck)
        {
            DeckType deckType;
            if (deck.DeckType)
            {
                deckType = DeckType.Public;
            }
            else
            {
                deckType = DeckType.Private;
            }
            var deckData = new Deck()
            {
                Name = deck.Name,
                Description = deck.Description,
                DeckType = deckType,
            };
            this.data.Decks.Add(deckData);
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

        public string GetId(string name)
        {
            return data.Decks.FirstOrDefault(x => x.Name == name).Id;
        }
    }


}
