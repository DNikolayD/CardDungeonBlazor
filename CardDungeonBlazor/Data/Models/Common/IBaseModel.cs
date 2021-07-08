using System;

namespace CardDungeonBlazor.Data.Models.Common
{
    public interface IBaseModel
    {

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
