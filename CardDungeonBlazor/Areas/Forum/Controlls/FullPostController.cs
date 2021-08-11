using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.ServiceToView;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Services.Services;

namespace CardDungeonBlazor.Areas.Forum.Controlls
    {
    public class FullPostController : ComponentBase
        {
        [Inject]
        protected PostsService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }


        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public FullPostViewModel Model;

        public CommentViewModel CommentModel;

        public GetViewModelsFromServiceModels Get;

        public bool addingComment = false;

        protected override void OnInitialized ()
            {
            this.CommentModel = new();
            this.Model = this.Get.GetFullPostViewModel(this.Service.GetFullPost(this.Id));
            base.OnInitialized();
            }

        public void Submit ()
            {
            this.CommentModel.Username = this.HttpContext.HttpContext.User.Identity.Name;
            this.Service.AddComment(this.Id, this.Get.GetCommentServiceModel(this.CommentModel));
            this.addingComment = false;
            }

        public void AddComment ()
            {
            this.addingComment = true;
            }
        }
    }
