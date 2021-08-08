namespace CardDungeonBlazor.Models
    {
    public class GameViewModel
        {

        public GameViewModel()
            {
            this.PlayerModel1 = new PlayerViewModel();
            this.PlayerModel2 = new PlayerViewModel();
            }

        public PlayerViewModel PlayerModel1 { get; set; }

        public PlayerViewModel PlayerModel2 { get; set; }
        }
    }
