using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;

namespace CardDungeonBlazor.Areas.Forum.Controlls
    {
    public class AddPostsController : ComponentBase
        {
        [Inject]
        protected IPostsService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public AddPostFormModel Model;

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = new AddPostFormModel()
                {
                CategoryId = Id,
                UserId = this.Service.GetUserId(this.HttpContext.HttpContext.User.Identity.Name),
                Likes = 0,
                };
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.AddPost(this.Get.GetAddPostServiceModel(this.Model));
            this.Navigation.NavigateTo($"/posts/{this.Id}/all");
            }
        }
    }
