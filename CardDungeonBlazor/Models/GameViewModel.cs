using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Models
{
    public class GameViewModel
    {

        public GameViewModel()
        {
            PlayerModel1 = new PlayerViewModel();
            PlayerModel2 = new PlayerViewModel();
        }

        public PlayerViewModel PlayerModel1 { get; set; }

        public PlayerViewModel PlayerModel2 { get; set; }
    }
}
