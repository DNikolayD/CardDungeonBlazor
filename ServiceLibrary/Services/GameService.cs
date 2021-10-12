using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using ServiceLibrary.Interfaces;
using ServiceLibrary.MannualMapping;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.GameModels;

namespace ServiceLibrary.Services
    {
    public class GameService : IGameService
        {

        private readonly ApplicationDbContext dbContext;

        public GameService ( ApplicationDbContext dbContext )
            {
            this.dbContext = dbContext;
            }

        public GameServiceModel Game { get; set; }

        public void EndTurn ()
            {
            if (this.Game.Player1.Name == this.Game.ActivePlayerName)
                {
                if (CheckIfDead(this.Game.Player1, this.Game.Player1.TurnsPoisoned))
                    {
                    this.dbContext.Users.FirstOrDefault(x => x.NickName == this.Game.Player1.Name).Loses++;
                    }
                else
                    {
                    this.Game.Player1.Health -= this.Game.Player1.TurnsPoisoned;
                    this.Game.Player1.TurnsPoisoned--;
                    }
                this.Game.Player1.Deck.Cards.InsertRange(this.Game.Player1.Deck.Cards.Count, this.Game.Player1.DiscardPile);
                this.Game.Player1.DiscardPile = new();
                }
            else if (this.Game.Player2.Name == this.Game.ActivePlayerName)
                {
                if (CheckIfDead(this.Game.Player2, this.Game.Player2.TurnsPoisoned))
                    {
                    this.dbContext.Users.FirstOrDefault(x => x.NickName == this.Game.Player1.Name).Wins++;
                    }
                else
                    {
                    this.Game.Player2.Health -= this.Game.Player2.TurnsPoisoned;
                    this.Game.Player2.TurnsPoisoned--;
                    }
                this.Game.Player2.Deck.Cards.InsertRange(this.Game.Player2.Deck.Cards.Count, this.Game.Player2.DiscardPile);
                this.Game.Player2.DiscardPile = new();
                }

            }

        public void LoadGame ( string playerName, string deckId )
            {
            this.Game.ActivePlayerName = playerName;
            Deck deck = this.dbContext.Decks.Find(deckId);
            DeckServiceModel deckServiceModel = MappingFromDbToService.DeckMapping(deck);
            PlayerServiceModel playerServiceModel = new();
            playerServiceModel.Name = this.Game.ActivePlayerName;
            playerServiceModel.Deck = deckServiceModel;
            playerServiceModel = Draw(playerServiceModel);
            this.Game.Player1 = playerServiceModel;
            PlayerServiceModel bot = new();
            Deck botDeck = this.dbContext.Decks.FirstOrDefault();
            bot.Deck = MappingFromDbToService.DeckMapping(botDeck);
            bot.Name = "Bot";
            }

        public void PlayCard ( string playerName, string cardId )
            {
            if (playerName == this.Game.ActivePlayerName)
                {
                Card card = this.dbContext.Cards.Find(cardId);
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                if (this.Game.Player1.Name == playerName && this.Game.Player1.Energy < cardServiceModel.Cost)
                    {
                    return;
                    }
                if (this.Game.Player2.Name == playerName && this.Game.Player2.Energy < cardServiceModel.Cost)
                    {
                    return;
                    }
                if (cardServiceModel.CardType.Name == "Attack")
                    {
                    if (this.Game.Player1.Name == playerName)
                        {
                        if (this.Game.Player2.Armor >= cardServiceModel.Value)
                            {
                            this.Game.Player2.Armor -= cardServiceModel.Value;
                            }
                        else
                            {
                            int value = cardServiceModel.Value;
                            value -= this.Game.Player2.Armor;
                            this.Game.Player2.Armor = 0;
                            if (CheckIfDead(this.Game.Player2, value))
                                {
                                this.dbContext.Users.FirstOrDefault(x => x.NickName == this.Game.ActivePlayerName).Wins++;
                                }
                            else
                                {
                                this.Game.Player2.Health -= value;
                                }
                            }
                        }
                    else
                        {
                        if (this.Game.Player1.Armor >= cardServiceModel.Value)
                            {
                            this.Game.Player1.Armor -= cardServiceModel.Value;
                            }
                        else
                            {
                            int value = cardServiceModel.Value;
                            value -= this.Game.Player1.Armor;
                            this.Game.Player1.Armor = 0;
                            if (CheckIfDead(this.Game.Player1, value))
                                {
                                this.dbContext.Users.FirstOrDefault(x => x.NickName == this.Game.Player1.Name).Loses++;
                                }
                            else
                                {
                                this.Game.Player1.Health -= value;
                                }
                            }
                        }
                    }
                else if (cardServiceModel.CardType.Name == "Heal")
                    {
                    if (this.Game.Player1.Name == playerName)
                        {
                        if (this.Game.Player1.Health + cardServiceModel.Value > 100)
                            {
                            this.Game.Player1.Health = 100;
                            }
                        else
                            {
                            this.Game.Player1.Health += cardServiceModel.Value;
                            }
                        }
                    else
                        {
                        if (this.Game.Player2.Health + cardServiceModel.Value > 100)
                            {
                            this.Game.Player2.Health = 100;
                            }
                        else
                            {
                            this.Game.Player2.Health += cardServiceModel.Value;
                            }
                        }
                    }
                else if (cardServiceModel.CardType.Name == "Deffence")
                    {
                    if (this.Game.Player1.Name == playerName)
                        {
                        this.Game.Player1.Armor += cardServiceModel.Value;
                        }
                    else
                        {
                        this.Game.Player2.Armor += cardServiceModel.Value;
                        }
                    }
                else if (cardServiceModel.CardType.Name == "Poison")
                    {
                    if (this.Game.Player1.Name == playerName)
                        {
                        this.Game.Player2.TurnsPoisoned += cardServiceModel.Value;
                        }

                    else
                        {
                        this.Game.Player1.TurnsPoisoned += cardServiceModel.Value;
                        }
                    }
                }
            }

        private static PlayerServiceModel Draw ( PlayerServiceModel playerServiceModel )
            {
            List<CardServiceModel> hand = playerServiceModel.Deck.Cards.GetRange(0, 5);
            playerServiceModel.Deck.Cards.RemoveRange(0, 5);
            playerServiceModel.Hand = hand;
            return playerServiceModel;
            }
        private static bool CheckIfDead ( PlayerServiceModel playerServiceModel, int value )
            {
            return playerServiceModel.Health < value;
            }
        }
    }
