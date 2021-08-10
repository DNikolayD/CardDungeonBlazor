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
    public class AddPostsController : ComponentBase
        {
        [Inject]
        protected PostsService Service { get; set; }

        [Inject]
        protected IHttpContextAccessor HttpContext { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        [Parameter]
        public string Id { get; set; }

        public AddPostFormModel Model;

        protected override void OnInitialized ()
            {
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
            this.Service.AddPost(this.Model);
            this.Navigation.NavigateTo($"/posts/{this.Id}/all");
            }
        }
    }
