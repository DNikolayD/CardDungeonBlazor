using CardDungeonBlazor.Data.Models.Common;
using Microsoft.AspNetCore.Identity;
using System;


namespace CardDungeonBlazor.Data.Models.User
{
    public class ApplicationRole : IdentityRole, IBaseModel
    {
        public ApplicationRole() : this(null)
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow;
        }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsEdited { get; set; }
        public DateTime? EditedOn { get; set; }
    }
}
