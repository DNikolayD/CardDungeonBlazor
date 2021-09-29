using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data.Models.User;
using Services.ServiceModels.CardsModels;
using Services.ServiceModels.ForumsModels;

namespace Services.ServiceModels.UserModels
    {
    public class Show
        {
        public Show ()
            {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.CreatedCards = new HashSet<CardServiceModel>();
            this.CreatedDecks = new HashSet<DeckServiceModel>();
            this.Posts = new HashSet<PostServiceModel>();
            this.Comments = new HashSet<CommentServiceModel>();
            this.LikedPosts = new HashSet<PostServiceModel>();
            this.LikedComments = new HashSet<CommentServiceModel>();
            }

        public string Id { get; set; }

        public string NickName { get; set; }

        public ImageServiceModel ProfilePhoto { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsEdited { get; set; }
        public DateTime? EditedOn { get; set; }

        public string RoleId { get; set; }

        public virtual ApplicationRole Role { get; set; }

        public int? Wins { get; set; }

        public int? Loses { get; set; }

        public virtual ICollection<CardServiceModel> CreatedCards { get; set; }

        public virtual ICollection<DeckServiceModel> CreatedDecks { get; set; }

        public virtual ICollection<PostServiceModel> Posts { get; set; }

        public virtual ICollection<CommentServiceModel> Comments { get; set; }

        public virtual ICollection<PostServiceModel> LikedPosts { get; set; }

        public virtual ICollection<CommentServiceModel> LikedComments { get; set; }
        }
    }
