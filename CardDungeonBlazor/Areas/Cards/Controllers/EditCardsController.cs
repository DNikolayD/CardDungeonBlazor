using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class EditCardsController : ComponentBase
        {
        [Inject]
        protected ICardsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Parameter]
        public string Id { get; set; }

        public CardViewModel Model { get; set; }

        public List<CardTypeViewModel> CardTypes { get; set; }

        protected override void OnInitialized ()
            {
            CardServiceModel cardServiceModel = this.Service.ShowFull(this.Id);
            this.Model = MappingFromServiceToView.CardMapping(cardServiceModel);
            this.Model.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
            this.Model.CardType = MappingFromServiceToView.CardTypeMapping(cardServiceModel.CardType);
            this.CardTypes = new();
            List<CardTypeServiceModel> cardTypeServiceModels = this.Service.ShowTypes();
            foreach (CardTypeServiceModel cardTypeServiceModel in cardTypeServiceModels)
                {
                CardTypeViewModel cardTypeViewModel = MappingFromServiceToView.CardTypeMapping(cardTypeServiceModel);
                this.CardTypes.Add(cardTypeViewModel);
                }
            base.OnInitialized();
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
            cardServiceModel.CreatedByUser = this.Service.GetUserByName(this.HttpContext.HttpContext.User.Identity.Name);
            bool succsses = this.Service.Add(cardServiceModel);
            if (succsses)
                {
                this.Navigation.NavigateTo("/cards/all");
                }
            else
                {
                this.Navigation.NavigateTo("/");
                }
            }

        }
    }
