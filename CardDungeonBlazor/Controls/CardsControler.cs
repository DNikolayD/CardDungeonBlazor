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
                ImageUrl = card.ImageUrl,
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

        public AllCardsViewModel GetAllCards(ApplicationDbContext data)
        {
            AllCardsViewModel allCards = new();
            foreach (var card in data.Cards)
            {
                if (card.IsDeleted)
                {
                    continue;
                }
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

        public void Delete(string id)
        {
            this.data.Cards.FirstOrDefault(x => x.Id == id).IsDeleted = true;
            this.data.Cards.FirstOrDefault(x => x.Id == id).DeletedOn = DateTime.UtcNow;
            this.data.SaveChanges();
        }

        public FullCardViewModel GetFullCardView(string id)
        {
            var card = this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            return new FullCardViewModel()
            {
                CardType = card.CardType.Name,
                CreatedOn = card.CreatedOn.ToShortDateString(),
                Description = card.Description,
                Duration = card.Duration.GetValueOrDefault(),
                ImageUrl = card.ImageUrl,
                Name = card.Name,
                Value = card.Value,
            };
        }

        public CardEditFomModel GetEditFomModel(string id)
        {
            var card = this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            List<CardTypeViewModel> cardTypeViewModel = new();
            foreach (var cardType in data.CardTypes)
            {
                cardTypeViewModel.Add(new CardTypeViewModel
                {
                    Id = cardType.Id,
                    Name = cardType.Name
                });
            }

            return new CardEditFomModel()
            {
                Name = card.Name,
                Description = card.Description,
                ImageUrl = card.ImageUrl,
                CardTypeId = card.CardTypeId,
                CardTypes = cardTypeViewModel,
                Value = card.Value,
            };
        }

        public void Edit(string id, CardEditFomModel card)
        {
            this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted).CardTypeId = card.CardTypeId;
            this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted).Description = card.Description;
            this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted).ImageUrl = card.ImageUrl;
            this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted).Name = card.Name;
            this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted).Value = card.Value;
            this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted).EditedOn = DateTime.UtcNow;
            this.data.Cards.FirstOrDefault(x => x.Id == id && !x.IsDeleted).IsEdited = true;
            this.data.SaveChanges();
        }
    }
}
