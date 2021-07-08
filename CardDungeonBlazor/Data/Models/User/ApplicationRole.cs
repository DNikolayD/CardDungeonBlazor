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
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
