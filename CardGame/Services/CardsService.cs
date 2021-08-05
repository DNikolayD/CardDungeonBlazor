using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Services
{
    public class CardsService
    {
        private readonly CardModel card;

        public CardsService(CardModel card)
        {
            this.card = card;
        }

        public List<PlayerModel> TakeEffect(PlayerModel player1, PlayerModel player2)
        {
            if (player1.Energy >= card.Cost)
            {
                switch (this.card.Type)
                {
                    case TypeModel.Attack:
                        if (player2.Deffence >= this.card.Value)
                        {
                            player2.Deffence -= card.Value;
                        }
                        else
                        {
                            int demage = card.Value - player2.Deffence;
                            player2.Deffence = 0;
                            player2.Health -= demage;
                        }
                        break;
                    case TypeModel.Deffence:
                        player1.Deffence += card.Value;
                        break;
                    case TypeModel.Heal:
                        if (player1.Health != 100)
                        {
                            player1.Health += card.Value;
                        }
                        break;
                    case TypeModel.Poison:
                        player2.Health -= card.Value;
                        player2.IsPoisoned = this.card.Type.Equals(TypeModel.Poison);
                        break;
                    default:
                        break;
                }
                player1.Energy -= card.Cost;
            }
            return new List<PlayerModel> 
            {
                player1,
                player2
            };
        }
    }
}
