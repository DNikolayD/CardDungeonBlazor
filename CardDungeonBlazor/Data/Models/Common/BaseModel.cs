using System;
using System.ComponentModel.DataAnnotations;


namespace CardDungeonBlazor.Data.Models.Common
{
    public class BaseModel<TKey> : IBaseModel
    {
        [Key]
        public TKey Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set ; }
    }
}
