using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.ServiceToView;
using CardGame;
using CardGame.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using MudBlazor;
using Services.Interfaces;
using Services.ServiceModels.GameModels;
using Services.Services;

namespace CardDungeonBlazor.Controllers
    {
    public class GameController : ComponentBase
        {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        protected IGameService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Inject]
        protected IDialogService Dialog { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public GameViewModel Model { get; set; }

        public CardViewModel PlayedCard { get; set; }

        public List<CardViewModel> DescardedCards { get; set; }

        public GetViewModelsFromServiceModels Get;


        public bool cardIsPlayed = false;

        public bool IsPlayedCardHiden = true;

        public bool isDrawAnimationManual = false;

        protected override async Task OnInitializedAsync ()
            {
            this.Get = new();
            this.Model = new GameViewModel();
            this.Model.PlayerModel1.Name = this.HttpContext.HttpContext.User.Identity.Name;
            this.Model.PlayerModel2.Name = "bot";
            GameServiceModel gameServiceModel = this.Get.GetGameServiceModel(this.Model);
            this.Service.GameManager = new GameManager(GameService.GetPlayer(gameServiceModel, this.Model.PlayerModel1.Name), GameService.GetPlayer(gameServiceModel, this.Model.PlayerModel2.Name), 1);
            this.Model.PlayerModel1.Deck = this.Get.GetDecksViewModel(this.Service.GetDeck(this.Model.PlayerModel1.Name, this.Id));
            this.Model.PlayerModel2.Deck = this.Get.GetDecksViewModel(this.Service.GetDeck(this.Model.PlayerModel2.Name, this.Id));
            this.Model.PlayerModel1.CardsInHeand = this.Get.GetCardViewModels(await this.Service.GetCardsInHand());

            }


        public async Task PlayCard ( string cardId, string playerName )
            {
            PlayerViewModel player = new()
                {
                Name = playerName,
                };
            CardViewModel card = new();
            if (player.Name == this.Model.PlayerModel1.Name && this
                .Service.GameManager.GetPlayerName() == playerName)
                {
                this.Model.PlayedCard = this.Model.PlayerModel1.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
                }
            else if (player.Name == this.Model.PlayerModel2.Name && this
                .Service.GameManager.GetPlayerName() == playerName)
                {
                this.Model.PlayedCard = this.Model.PlayerModel2.CardsInHeand.FirstOrDefault(c => c.Id == cardId);
                }
            this.PlayedCard = this.Model.PlayedCard;
            this.Model = this.Get.GetGameViewModel(await this.Service.PlayCard(cardId, playerName, this.Get.GetGameServiceModel(this.Model)));
            this.Model.PlayedCard = this.PlayedCard;

            await Task.Delay(20);
            if (this.Model.PlayerModel1.Name == playerName)
                {
                this.Model.PlayedCard.Offcet = 0;
                this.Model.PlayerModel1.DiscardPile.Add(this.Model.PlayedCard);
                }
            else if (this.Model.PlayerModel2.Name == playerName)
                {
                this.Model.PlayedCard.Offcet = 0;
                this.Model.PlayerModel2.DiscardPile.Add(this.Model.PlayedCard);
                }
            if (!this.Service.GameManager.gameIsOn)
                {
                if (this.Service.GameManager.Player1.Name == this.HttpContext.HttpContext.User.Identity.Name && this.Service.GameManager.Player1.Health > 0)
                    {
                    bool? action = await this.Dialog.ShowMessageBox("Game over", "You won", yesText: "Play Again", cancelText: "Go to starting page");
                    if (action == null)
                        {

                        }
                    else if (action == true)
                        {
                        this.Navigation.NavigateTo($"/game/main/{this.Id}");
                        }
                    else
                        {
                        this.Navigation.NavigateTo("/");
                        }
                    }
                else
                    {
                    bool? action = await this.Dialog.ShowMessageBox("Game over", "You lost", yesText: "Play Again", cancelText: "Go to starting page");
                    }
                }
            _ = Task.Delay(100);
            this.Model.PlayedCard = null;

            }

        protected override void OnAfterRender ( bool firstRender )
            {
            foreach (CardViewModel deck in this.Model.PlayerModel2.Deck.Cards)
                {
                deck.Offcet = 0;
                }
            foreach (CardViewModel deck in this.Model.PlayerModel1
                  .Deck.Cards)
                {
                deck.Offcet = 0;
                }
            }

        public async Task EndTurn ()
            {
            await this.Service.EndTurn();

            if (this.Service.GameManager.GetPlayerName() == this.Model.PlayerModel1.Name)
                {
                this.Model.PlayerModel2.CardsInHeand = this.Get.GetCardViewModels(await this.Service.GetCardsInHand());
                this.Model.PlayerModel1.DiscardPile = new();
                this.Service.Enemy = new(this.Service.GameManager);
                if (this.Service.GameManager.level == 1)
                    {
                    if (this.Service.GameManager.Player1.Name == this.Service.GameManager.GetPlayerName())
                        {
                        while (this.Service.GameManager.Player1.CardsInHeand[0].Cost <= this.Service.GameManager.Player1.Energy)
                            {
                            await Task.Delay(1000);
                            await this.PlayCard(this.Service.GameManager.Player1.CardsInHeand[0].Id, this.Service.GameManager.GetPlayerName());
                            await Task.Delay(100);
                            }
                        await this.EndTurn();
                        }
                    else
                        {
                        while (this.Service.GameManager.Player2.CardsInHeand[0].Cost <= this.Service.GameManager.Player2.Energy)
                            {
                            await this.PlayCard(this.Service.GameManager.Player2.CardsInHeand[0].Id, this.Service.GameManager.GetPlayerName());

                            }
                        await this.EndTurn();
                        }
                    }
                else if (this.Service.GameManager.level == 2)
                    {
                    if (this.Service.GameManager.Player1.Name == this.Service.GameManager.GetPlayerName())
                        {
                        if (this.Service.GameManager.Player1.Health <= 20)
                            {
                            if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else
                                {
                                await this.Service.GameManager.Update(GameEvents.EndTurn);
                                }
                            }
                        else
                            {
                            if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Attack && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Attack && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else
                                {
                                await this.Service.GameManager.Update(GameEvents.EndTurn);
                                }
                            }
                        }
                    else
                        {
                        if (this.Service.GameManager.Player2.Health <= 20)
                            {
                            if (this.Service.GameManager.Player2.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player2.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player2.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player2.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player2.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.Service.GameManager.Player2.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player2.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player2.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player2.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player2.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player2.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player2.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player2.CardsInHeand.Any(c => c.Cost <= this.Service.GameManager.Player2.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player2.CardsInHeand.FirstOrDefault(c => c.Cost <= this.Service.GameManager.Player2.Energy).Id);
                                }
                            else
                                {
                                await this.Service.GameManager.Update(GameEvents.EndTurn);
                                }
                            }
                        else
                            {
                            if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Poison && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Attack && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Attack && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            else if (this.Service.GameManager.Player1.CardsInHeand.Any(c => c.Type == TypeModel.Deffence && c.Cost <= this.Service.GameManager.Player1.Energy))
                                {
                                await this.Service.GameManager.Update(GameEvents.SelectCard, this.Service.GameManager.Player1.CardsInHeand.FirstOrDefault(c => c.Type == TypeModel.Heal && c.Cost <= this.Service.GameManager.Player1.Energy).Id);
                                }
                            }
                        }
                    }
                }
            else
                {
                this.Model.PlayerModel1.CardsInHeand = this.Get.GetCardViewModels(await this.Service.GetCardsInHand());
                this.Model.PlayerModel2.DiscardPile = new();
                }

            }
        private void UpdateGameState ( CardModel cardModel )
            {
            string imageUrl = string.Empty;
            if (this.Service.GameManager.GetPlayerName() == this.Model.PlayerModel1.Name)
                {
                imageUrl = this.Model.PlayerModel1.CardsInHeand.FirstOrDefault(c => c.Id == cardModel.Id).ImageUrl;
                }
            else if (this.Service.GameManager.GetPlayerName() == this.Model.PlayerModel2.Name)
                {
                imageUrl = this.Model.PlayerModel2.CardsInHeand.FirstOrDefault(c => c.Id == cardModel.Id).ImageUrl;
                }
            this.Model.PlayedCard = new CardViewModel
                {
                Id = cardModel.Id,
                Cost = cardModel.Cost,
                ImageUrl = imageUrl,
                IsHidden = false,
                Name = cardModel.Name,
                Offcet = 0,
                Type = cardModel.Type.ToString(),
                Value = cardModel.Value,
                };
            }
        }
    }
