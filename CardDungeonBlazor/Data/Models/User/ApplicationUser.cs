using CardDungeonBlazor.Data.Models.CardModels;
using CardDungeonBlazor.Data.Models.Common;
using CardDungeonBlazor.Data.Models.PostModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace CardDungeonBlazor.Data.Models.User
{
    public class ApplicationUser : IdentityUser, IBaseModel
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow;
            CreatedCards = new HashSet<Card>();
            CreatedDecks = new HashSet<Deck>();
            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
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
