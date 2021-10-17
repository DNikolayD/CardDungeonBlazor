using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using MudBlazor;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class AddCardController : ComponentBase
        {
        [Inject]
        protected ICardsService CardsService { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        public CardViewModel Model { get; set; }

        public List<CardTypeViewModel> CardTypes { get; set; }

        public MudMessageBox Mbox { get; set; }

        public bool IsVisible { get; set; }

        protected override void OnInitialized ()
            {
            this.Model = new();
            this.CardTypes = new();
            List<CardTypeServiceModel> cardTypeServiceModels = this.CardsService.ShowTypes();
            foreach (CardTypeServiceModel cardTypeServiceModel in cardTypeServiceModels)
                {
                CardTypeViewModel cardTypeViewModel = MappingFromServiceToView.CardTypeMapping(cardTypeServiceModel);
                this.CardTypes.Add(cardTypeViewModel);
                }
            }

        public async Task UploadFiles ( InputFileChangeEventArgs e )
            {
            IBrowserFile file = e.File;
            byte[] buffer = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffer);
            this.Model.Image.Img = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";
            this.Model.Image.Name = this.Model.Image.Img;

            }
        public void Submit ()
            {
            CardServiceModel cardServiceModel = MappingFromViewToService.CardMapping(this.Model);
            cardServiceModel.Image = MappingFromViewToService.ImageMapping(this.Model.Image);
            cardServiceModel.CreatedByUser = this.CardsService.GetUserByName(this.HttpContext.HttpContext.User.Identity.Name);
            bool succsses = this.CardsService.Add(cardServiceModel);
            if (succsses)
                {
                this.Navigation.NavigateTo("/cards/all");
                }
            else
                {
                this.DialogService.ShowMessageBox("Fail", "You have failed to add a card");
                this.Navigation.NavigateTo("/");
                }
            }
        }
    }
