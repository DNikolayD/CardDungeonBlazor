using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Data.Models.CardModels
    {
    public class CardDeck
        {
        [Key]
        public int Id { get; set; }

        public string CardId { get; set; }

        public virtual Card Card { get; set; }

        public string DeckId { get; set; }

        public virtual Deck Deck { get; set; }
        }
    }
