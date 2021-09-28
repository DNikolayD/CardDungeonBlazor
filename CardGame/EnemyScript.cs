using System.Linq;
using System.Threading.Tasks;
using CardGame.Models;

namespace CardGame
    {
    public class EnemyScript
        {
        private readonly GameManager game;

        public EnemyScript ( GameManager game )
            {
            this.game = game;
            }

        public async Task Play ()
            {
            if (this.game.level == 1)
                {
                if (this.game.Player1.Name == this.game.GetPlayerName())
                    {
                    while (this.game.Player1.CardsInHeand[0].Cost <= this.game.Player1.Energy)
                        {
                        await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand[0].Id);
                        }
                    await this.game.Update(GameEvents.EndTurn);
                    }
                else
                    {
                    while (this.game.Player2.CardsInHeand[0].Cost <= this.game.Player2.Energy)
                        {
                        await this.game.Update(GameEvents.SelectCard, this.game.Player2.CardsInHeand[0].Id);
                        }
                    await this.game.Update(GameEvents.EndTurn);
                    }
                }
            else if (this.game.level == 2)
                {
                if (this.game.Player1.Name == this.game.GetPlayerName())
                    {
                    if (this.game.Player1.Health <= 20)
                        {
                        if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else
                            {
                            await this.game.Update(GameEvents.EndTurn);
                            }
                        }
                    else
                        {
                        if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Attack && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Attack && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else
                            {
                            await this.game.Update(GameEvents.EndTurn);
                            }
                        }
                    }
                else
                    {
                    if (this.game.Player2.Health <= 20)
                        {
                        if (this.game.Player2.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player2.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player2.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player2.Energy).Id);
                            }
                        else if (this.game.Player2.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.game.Player2.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player2.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player2.Energy).Id);
                            }
                        else if (this.game.Player2.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player2.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player2.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player2.Energy).Id);
                            }
                        else if (this.game.Player2.CardsInHeand.Any(c => c.Cost <= this.game.Player2.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player2.CardsInHeand.FirstOrDefault(c => c.Cost <= this.game.Player2.Energy).Id);
                            }
                        else
                            {
                            await this.game.Update(GameEvents.EndTurn);
                            }
                        }
                    else
                        {
                        if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Attack && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Attack && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        else if (this.game.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.game.Player1.Energy))
                            {
                            await this.game.Update(GameEvents.SelectCard, this.game.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.game.Player1.Energy).Id);
                            }
                        }
                    }
                }

            }
        }
    }

