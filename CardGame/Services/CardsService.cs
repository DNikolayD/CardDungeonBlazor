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
            if (this.card == null)
                {
                return null;
                }
            if (player1.Energy >= this.card.Cost)
                {
                switch (this.card.Type)
                    {
                    case TypeModel.Attack:
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
                        break;
                    case TypeModel.Deffence:
                        player1.Deffence += this.card.Value;
                        break;
                    case TypeModel.Heal:
                        if (player1.Health != 100)
                            {
                            player1.Health += this.card.Value;
                            }
                        break;
                    case TypeModel.Poison:
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
                       
                        break;
                    default:
                        break;
                    }
                player1.Energy -= this.card.Cost;
                }
            return new List<PlayerModel>
                  {
                        player1,
                        player2
                  };
            }
        }
    }
