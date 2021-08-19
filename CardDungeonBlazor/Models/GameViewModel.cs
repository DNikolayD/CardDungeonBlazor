using CardDungeonBlazor.Areas.Cards.Models;

namespace CardDungeonBlazor.Areas.Cards
    {
    public class GameViewModel
        {

        public GameViewModel ()
            {
            this.PlayerModel1 = new PlayerViewModel();
            this.PlayerModel2 = new PlayerViewModel();

            }

        public PlayerViewModel PlayerModel1 { get; set; }

        public PlayerViewModel PlayerModel2 { get; set; }

        public CardViewModel PlayedCard { get; set; }
        }
    }
