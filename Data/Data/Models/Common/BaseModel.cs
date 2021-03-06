using System;
using System.ComponentModel.DataAnnotations;


namespace CardDungeonBlazor.Data.Models.Common
    {
    public class BaseModel<TKey> : IBaseModel
        {

        public BaseModel ()
            {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.IsEdited = false;
            }

        [Key]
        public TKey Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsEdited { get; set; }

        public DateTime? EditedOn { get; set; }
        }
    }
