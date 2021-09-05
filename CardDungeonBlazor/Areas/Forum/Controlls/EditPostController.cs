using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;
using Services.Services;

namespace CardDungeonBlazor.Areas.Forum.Controlls
    {
    public class EditPostController : ComponentBase
        {
        [Inject]
        protected IPostsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public AddPostFormModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Model = this.Get.GetAddPostFormModel(this.Service.GetPostsForm(this.Id));
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.Edit(this.Get.GetAddPostServiceModel(this.Model), this.Id);
            this.Navigation.NavigateTo($"/posts/{this.Id}/more");
            }
        }
    }
