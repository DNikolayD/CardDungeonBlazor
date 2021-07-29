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
            if (deck.DeckType == DeckType.Public)
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
            string cardImage = "";
            foreach (var deck in data.Decks.Where(x => !x.IsDeleted))
            {
                if (data.Cards.FirstOrDefault(x => x.Id == data.CardDecks.FirstOrDefault(x => x.DeckId == deck.Id).CardId).ImageUrl.Any())
                {
                    cardImage = data.Cards.FirstOrDefault(x => x.Id == data.CardDecks.FirstOrDefault(x => x.DeckId == deck.Id).CardId).ImageUrl;
                }
                allDecks.Decks.Add(new DeckServiceModel
                {
                    Id = deck.Id,
                    Type = deck.DeckType.ToString(),
                    Name = deck.Name,
                    ImageUrl = cardImage,
                    Cards = data.CardDecks.Where(x => x.DeckId == deck.Id).Count(),
                });
            }
            
            return allDecks;
        }

        public string GetId(string name)
        {
            return data.Decks.FirstOrDefault(x => x.Name == name).Id;
        }

        public void Delete(string id)
        {
            this.data.Decks.FirstOrDefault(x => x.Id == id).IsDeleted = true;
        }

        public AddDeckFormModel GetDeck(string id)
        {
            return new AddDeckFormModel
            {
                Name = this.data.Decks.FirstOrDefault(x => x.Id == id).Name,
                DeckType = this.data.Decks.FirstOrDefault(x => x.Id == id).DeckType,
                Description = this.data.Decks.FirstOrDefault(x => x.Id == id).Description,
            };

        }
        public void Edit(string id, AddDeckFormModel model)
        {
            this.data.Decks.FirstOrDefault(x => x.Id == id).Name = model.Name;
            this.data.Decks.FirstOrDefault(x => x.Id == id).DeckType = model.DeckType;
            this.data.Decks.FirstOrDefault(x => x.Id == id).Description = model.Description;


            this.data.SaveChanges();
        }

        public FullDeckViewModel GetFullDeckView(string id)
        {
            return new FullDeckViewModel
            {
                Name = data.Decks.FirstOrDefault(x => x.Id == id).Name,
                Description = data.Decks.FirstOrDefault(x => x.Id == id).Description,
                Type = data.Decks.FirstOrDefault(x => x.Id == id).DeckType.ToString(),
                CreatedOn = data.Decks.FirstOrDefault(x => x.Id == id).CreatedOn.ToShortDateString(),
                NumberOfCards = data.CardDecks.Where(x => x.DeckId == id).Count()
            };
        }
    }


}
