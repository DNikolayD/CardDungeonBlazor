using System.Collections.Generic;
using CardGame.Models;

namespace CardGame.Services
    {
    public class CardsService
        {
        private readonly CardModel card;

        public CardsService ( CardModel card )
            {
            this.card = card;
            }

        public List<PlayerModel> TakeEffect ( PlayerModel player1, PlayerModel player2 )
            {
            List<PlayerModel> players = new()
                {
                player1,
                player2
                };
            if (player1.Energy >= this.card.Cost)
                {
                switch (this.card.Type)
                    {
                    case TypeModel.Attack:
                        players = this.ResolveAttack(player1, player2);
                        break;
                    case TypeModel.Deffence:
                        players[0].Deffence += this.card.Value;
                        break;
                    case TypeModel.Heal:
                        if (players[0].Health != 100)
                            {
                            players[0].Health += this.card.Value;
                            }
                        break;
                    case TypeModel.Poison:
                        players[1] = this.ResolvePoison(players[1]);
                        break;
                    default:
                        break;
                    }
                players[0].Energy -= this.card.Cost;
                }
            return players;
            }
        private List<PlayerModel> ResolveAttack ( PlayerModel player1, PlayerModel player2 )
            {
            if (player2.Deffence >= this.card.Value)
                {
                player2.Deffence -= this.card.Value;
                }
            else
                {
                int demage = this.card.Value - player2.Deffence;
                player2.Deffence = 0;
                player2.Health -= demage;
                }
            return
                new List<PlayerModel>
                  {
                        player1,
                        player2
                  };
            }
        private PlayerModel ResolvePoison ( PlayerModel player2 )
            {
            if (!player2.IsPoisoned)
                {
                player2.Health -= this.card.Value;
                player2.IsPoisoned = this.card.Type.Equals(TypeModel.Poison);
                player2.TurnsPoisoned = this.card.Value;
                }
            else
                {
                player2.TurnsPoisoned += this.card.Value;
                player2.Health -= player2.TurnsPoisoned;
                }
            return player2;
            }
        }
    }
