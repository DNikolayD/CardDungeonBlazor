using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace CardDungeonBlazor.Areas.Forum.Controlls
    {
    public class EditPostController : ComponentBase
        {
        [Inject]
        protected PostsService Service { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public AddPostFormModel Model;

        protected override void OnInitialized ()
            {
            this.Model = this.Service.GetPostsForm(this.Id);
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.Service.Edit(this.Model, this.Id);
            Navigation.NavigateTo($"/posts/{this.Id}/more");
            }
        }
    }
