using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public List<CardViewModel>  Models { get; set; }

        protected override void OnInitialized ()
            {
            Models = new();
            List<CardServiceModel> cardServiceModels = Service.Show(HttpContext.HttpContext.User.Identity.Name);
            foreach (CardServiceModel cardServiceModel in cardServiceModels)
                {
                CardViewModel cardViewModel = MappingFromServiceToView.CardMapping(cardServiceModel);
                cardViewModel.Image = MappingFromServiceToView.ImageMapping(cardServiceModel.Image);
                Models.Add(cardViewModel);
                }

            base.OnInitialized();
            }
        public void RedirectToFullView(string cardId )
            {

            }

        public void RedirectToEdit ( string cardId )
            {

            }
        public void Delete ( string cardId)
            {

            }
        public void Redirect ()
            {

            }
        }
    }
