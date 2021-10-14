namespace CardDungeonBlazor.Models
    {
    public class GameViewModel
        {

        public GameViewModel ()
            {
            this.Player1 = new();
            this.Player2 = new();

            }

        public PlayerViewModel Player1 { get; set; }

        public PlayerViewModel Player2 { get; set; }

        public string ActivePlayerName { get; set; }
        }
    }
