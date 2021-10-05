using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Models.GameModels
    {
    public class GameServiceModel
        {
        public string ActivePlayerName { get; set; }

        public PlayerServiceModel Player1 { get; set; }

        public PlayerServiceModel Player2 { get; set; }
        }
    }
