using System;
using System.Collections.Generic;
using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.PostModels;
using Microsoft.AspNetCore.Identity;


namespace CardDungeonBlazor.Data.Models.User
    {
    public class ApplicationUser : IdentityUser, IBaseModel
        {
        public ApplicationUser ()
            {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.CreatedCards = new HashSet<Card>();
            this.CreatedDecks = new HashSet<Deck>();
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
            }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsEdited { get; set; }
        public DateTime? EditedOn { get; set; }

        public string RoleId { get; set; }

        public virtual ApplicationRole Role { get; set; }

        public virtual ICollection<Card> CreatedCards { get; set; }

        public virtual ICollection<Deck> CreatedDecks { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        }
    }
