using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Services.Services;

namespace CardDungeonBlazor.Areas.Forum.Controlls
    {
    public class AllPostsController : ComponentBase
        {
        [Inject]
        protected PostsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public AllPostsViewModel Model { get; set; }

        public GetViewModelsFromServiceModels Get;

        protected override void OnInitialized ()
            {
            this.Get = new();
            this.Model = this.Get.GetAllPostsViewModel(this.Service.GetPosts(this.Id));
            base.OnInitialized();
            }

        public void Redirect ()
            {
            this.Navigation.NavigateTo($"/posts/{this.Id}/add");
            }

        public void RedirectToPost ( string id )
            {
            this.Navigation.NavigateTo($"/posts/{id}/more");
            }

        public void RedirectToEdit ( string id )
            {
            this.Navigation.NavigateTo($"/posts/{id}/edit");
            }

        public void Delete ( string id )
            {
            this.Service.Delete(id);
            this.OnInitialized();
            }
        }
    }
