namespace CardGame.Models
    {
    public class CardModel
        {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public TypeModel Type { get; set; }

        public int Value { get; set; }
        }
    }
