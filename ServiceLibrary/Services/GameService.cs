using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.User;
using Data.Data.Models.Common;
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
            this.Game = new();
            this.dbContext = dbContext;
            }

        public GameServiceModel Game { get; set; }

        public async Task EndTurn ()
            {
            if (this.Game.Player1.Name == this.Game.ActivePlayerName)
                {
                if (CheckIfDead(this.Game.Player1, this.Game.Player1.TurnsPoisoned))
                    {
                    this.Game.Player1.Health = 0;
                    this.dbContext.Users.FirstOrDefault(x => x.UserName == this.Game.Player1.Name).Loses++;
                    }
                else
                    {
                    this.Game.Player1.Health -= this.Game.Player1.TurnsPoisoned;
                    if (this.Game.Player1.TurnsPoisoned > 0)
                        {
                        this.Game.Player1.TurnsPoisoned--;
                        }
                    }
                this.Game.Player1.Energy = this.Game.Player1.MaxEnergy;
                this.Game.Player1.DiscardPile.InsertRange(Game.Player1.DiscardPile.Count, Game.Player1.Hand);
                this.Game.Player1.Deck.Cards.InsertRange(this.Game.Player1.Deck.Cards.Count, this.Game.Player1.DiscardPile);
                this.Game.Player1.DiscardPile = new();
                this.Game.ActivePlayerName = this.Game.Player2.Name;
                this.Game.Player2 = Draw(this.Game.Player2);
                }
            else if (this.Game.Player2.Name == this.Game.ActivePlayerName)
                {
                if (CheckIfDead(this.Game.Player2, this.Game.Player2.TurnsPoisoned))
                    {
                    this.Game.Player2.Health = 0;
                    this.dbContext.Users.FirstOrDefault(x => x.UserName == this.Game.Player1.Name).Wins++;
                    }
                else
                    {
                    this.Game.Player2.Health -= this.Game.Player2.TurnsPoisoned;
                    if (this.Game.Player2.TurnsPoisoned > 0)
                        {
                        this.Game.Player2.TurnsPoisoned--;
                        }
                    }
                this.Game.Player2.DiscardPile.InsertRange(Game.Player2.DiscardPile.Count, Game.Player2.Hand);

                this.Game.Player2.Energy = this.Game.Player2.MaxEnergy;
                this.Game.Player2.Deck.Cards.InsertRange(this.Game.Player2.Deck.Cards.Count, this.Game.Player2.DiscardPile);
                this.Game.Player2.DiscardPile = new();
                this.Game.ActivePlayerName = this.Game.Player1.Name;
                this.Game.Player1 = Draw(this.Game.Player1);
                }

            }

        public void LoadGame ( string playerName, string deckId, int enemyDeck, int draw, int health, int energy )
            {
            this.Game.ActivePlayerName = playerName;
            Deck deck = this.dbContext.Decks.Find(deckId);
            DeckServiceModel deckServiceModel = MappingFromDbToService.DeckMapping(deck);
            List<CardServiceModel> cardServiceModels = new();
            List<CardDeck> cardDecks = this.dbContext.CardDecks.Where(x => x.DeckId == deck.Id).ToList();
            foreach (CardDeck cardDeck in cardDecks)
                {
                Card card = this.dbContext.Cards.First(x => x.Id == cardDeck.CardId);
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                Image image = this.dbContext.Images.Find(card.ImageId);
                CardType cardType = this.dbContext.CardTypes.Find(card.CardTypeId);
                ApplicationUser applicationUser = this.dbContext.Users.Find(card.CreatedByUserId);
                cardServiceModel.Image = MappingFromDbToService.ImageMapping(image);
                cardServiceModel.CardType = MappingFromDbToService.CardTypeMapping(cardType);
                cardServiceModel.CreatedByUser = MappingFromDbToService.UserMapping(applicationUser);
                cardServiceModels.Add(cardServiceModel);
                }
            deckServiceModel.Cards = cardServiceModels;
            PlayerServiceModel playerServiceModel = new(health, energy, draw);
            playerServiceModel.Name = this.Game.ActivePlayerName;
            playerServiceModel.Deck = deckServiceModel;
            playerServiceModel = Draw(playerServiceModel);
            this.Game.Player1 = playerServiceModel;
            PlayerServiceModel bot = new(0,0,0);
            Deck botDeck = this.dbContext.Decks.FirstOrDefault(x => x.Name == "EditDeck");
            List<CardServiceModel> botCardServiceModels = new();
            Deck[] botDecksData = this.dbContext.Decks.ToArray().Reverse().ToArray();
            Deck botDeckData = new();
            if (enemyDeck < botDecksData.Length)
                {
                botDeckData = botDecksData[enemyDeck];
                }
            else
                {
                botDeckData = botDecksData.Last();

                }
            List<CardDeck> botCardDecks = this.dbContext.CardDecks.Where(x => x.DeckId == botDeckData.Id).ToList();
            foreach (CardDeck cardDeck in botCardDecks)
                {
                Card card = this.dbContext.Cards.First(x => x.Id == cardDeck.CardId);
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                Image image = this.dbContext.Images.Find(card.ImageId);
                CardType cardType = this.dbContext.CardTypes.Find(card.CardTypeId);
                ApplicationUser applicationUser = this.dbContext.Users.Find(card.CreatedByUserId);
                cardServiceModel.Image = MappingFromDbToService.ImageMapping(image);
                cardServiceModel.CardType = MappingFromDbToService.CardTypeMapping(cardType);
                cardServiceModel.CreatedByUser = MappingFromDbToService.UserMapping(applicationUser);
                botCardServiceModels.Add(cardServiceModel);
                }
            bot.Deck = MappingFromDbToService.DeckMapping(botDeck);
            bot.Deck.Cards = botCardServiceModels;
            bot.Name = "Bot";
            this.Game.Player2 = bot;
            }

        public void PlayCard ( string playerName, string cardId )
            {
            if (playerName == this.Game.ActivePlayerName)
                {
                Card card = this.dbContext.Cards.Find(cardId);
                CardServiceModel cardServiceModel = MappingFromDbToService.CardMapping(card);
                CardType cardType = this.dbContext.CardTypes.Find(card.CardTypeId);
                cardServiceModel.CardType = MappingFromDbToService.CardTypeMapping(cardType);
                ApplicationUser applicationUser = this.dbContext.Users.FirstOrDefault(x => x.Id == card.CreatedByUserId);
                Image image = this.dbContext.Images.FirstOrDefault(x => x.Id == card.ImageId);
                cardServiceModel.Image = MappingFromDbToService.ImageMapping(image);
                cardServiceModel.CreatedByUser = MappingFromDbToService.UserMapping(applicationUser);
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
                                this.Game.Player2.Health = 0;
                                this.dbContext.Users.FirstOrDefault(x => x.UserName == this.Game.ActivePlayerName).Wins++;
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
                                this.Game.Player1.Health = 0;
                                this.dbContext.Users.FirstOrDefault(x => x.UserName == this.Game.Player1.Name).Loses++;
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
                if (playerName == Game.Player1.Name)
                    {
                    this.Game.Player1.Energy -= cardServiceModel.Cost;
                    this.Game.Player1.Hand.Remove(this.Game.Player1.Hand.FirstOrDefault(x => x.Id == cardId));
                    this.Game.Player1.DiscardPile.Add(cardServiceModel);
                    }
                else if (playerName == Game.Player2.Name)
                    {
                    this.Game.Player2.Energy -= cardServiceModel.Cost;
                    this.Game.Player2.Hand.Remove(this.Game.Player2.Hand.FirstOrDefault(x => x.Id == cardId));
                    this.Game.Player2.DiscardPile.Add(cardServiceModel);
                    }
                }
            }

        private static PlayerServiceModel Draw ( PlayerServiceModel playerServiceModel )
            {
            List<CardServiceModel> hand = new();
            if (playerServiceModel.Deck.Cards.Count < playerServiceModel.Draw)
                {
                hand = playerServiceModel.Deck.Cards.GetRange(0, playerServiceModel.Deck.Cards.Count);
                playerServiceModel.Deck.Cards.RemoveRange(0, playerServiceModel.Deck.Cards.Count);
                }
            else
                {
                hand = playerServiceModel.Deck.Cards.GetRange(0, playerServiceModel.Draw);
                playerServiceModel.Deck.Cards.RemoveRange(0, playerServiceModel.Draw);
                }
            playerServiceModel.Hand = hand;
            return playerServiceModel;
            }
        private static bool CheckIfDead ( PlayerServiceModel playerServiceModel, int value )
            {
            return playerServiceModel.Health <= value;
            }
        }
    }
