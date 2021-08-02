using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Services
{
    public class PlayersService
    {
        private readonly PlayerModel player;
        public PlayersService(PlayerModel player)
        {
            this.player = player;
        }

        public PlayerModel Draw()
        {
            player.CardsInHeand.AddRange(player.Deck.Cards.GetRange(0, 5));
            player.Deck.Cards.RemoveRange(0, 5);
            return player;
        }
    }
}
