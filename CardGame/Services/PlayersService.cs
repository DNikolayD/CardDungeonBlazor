using CardGame.Models;

namespace CardGame.Services
    {
    public class PlayersService
        {
        private readonly PlayerModel player;
        public PlayersService ( PlayerModel player )
            {
            this.player = player;
            }

        public PlayerModel Draw ()
            {
            this.player.CardsInHeand.AddRange(this.player.Deck.Cards.GetRange(0, 5));
            this.player.Deck.Cards.RemoveRange(0, 5);
            return this.player;
            }
        }
    }
