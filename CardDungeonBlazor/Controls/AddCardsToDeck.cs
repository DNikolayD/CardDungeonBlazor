using CardDungeonBlazor.Data;
using CardDungeonBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Controls
{
    public class AddCardsToDeck
    {
        public AddCardsToDeckModel GetAllCards(ApplicationDbContext data)
        {
            AddCardsToDeckModel allCards = new();
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
