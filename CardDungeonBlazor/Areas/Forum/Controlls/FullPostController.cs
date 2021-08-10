using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Areas.Forum.Models;
using CardDungeonBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace CardDungeonBlazor.Areas.Forum.Controlls
    {
    public class FullPostController:ComponentBase
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

        public CommentServiceModel CommentModel;

        public bool addingComment = false;

        protected override void OnInitialized ()
            {
            CommentModel = new();
            Model = Service.GetFullPost(Id);
            base.OnInitialized();
            }

        public void Submit ()
            {
            CommentModel.Username = HttpContext.HttpContext.User.Identity.Name;
            Service.AddComment(Id, CommentModel);
            addingComment = false;
            }

        public void AddComment ()
            {
            addingComment = true;
            }
        }
    }
