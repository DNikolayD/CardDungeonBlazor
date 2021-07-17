using System;
using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Data.Models.Common
{
    public interface IBaseModel
    {

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        [Required]
        public bool IsEdited { get; set; }

        public DateTime? EditedOn { get; set; }
    }
}
