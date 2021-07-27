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

        public AllDeckViewModel GetAll(ApplicationDbContext data)
        {
            AllDeckViewModel allDecks = new();
            string cardImage = null;
            foreach (var deck in data.Decks)
            {
                if (deck.Cards.Count > 0)
                {
                    cardImage = deck.Cards.FirstOrDefault().Card.ImageUrl;
                }
                allDecks.Decks.Add(new DeckServiceModel
                {
                    Id = deck.Id,
                    Type = deck.DeckType.ToString(),
                    Name = deck.Name,
                    ImageUrl = cardImage,
                });
            }
            
            return allDecks;
        }

        public string GetId(string name)
        {
            return data.Decks.FirstOrDefault(x => x.Name == name).Id;
        }
    }


}
