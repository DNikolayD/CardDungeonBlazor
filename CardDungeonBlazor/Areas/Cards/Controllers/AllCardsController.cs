using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.MannualMapping;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using ServiceLibrary.Interfaces;
using ServiceLibrary.Models.CardModels;

namespace CardDungeonBlazor.Areas.Cards.Controllers
    {
    public class AllCardsController : ComponentBase
        {
        [Inject]
        protected ICardsService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        public List<CardViewModel> Models { get; set; }

        protected override void OnInitialized ()
            {
            this.Models = new();
            List<CardServiceModel> cardServiceModels = this.Service.Show(this.HttpContext.HttpContext.User.Identity.Name);
            foreach (CardServiceModel cardServiceModel in cardServiceModels)
                {
                CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                cardViewModel.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
                this.Models.Add(cardViewModel);
                }

            base.OnInitialized();
            }
        public void RedirectToFullView ( string cardId )
            {
            this.Navigation.NavigateTo($"/cards/fullView/{cardId}");
            }

        public void RedirectToEdit ( string cardId )
            {
            this.Navigation.NavigateTo($"/cards/edit/{cardId}");
            }
        public void Delete ( string cardId )
            {
            this.Service.Delete(cardId);
            this.OnInitialized();
            }
        public void Redirect ()
            {
            this.Navigation.NavigateTo("/cards/add");
            }
        }
    }
