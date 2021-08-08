namespace CardDungeonBlazor.Models
    {
    public class CardAddedToTheDeckViewModel
        {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string CardType { get; set; }

        public int Value { get; set; }

        public int TimesAdded { get; set; }
        }
    }
