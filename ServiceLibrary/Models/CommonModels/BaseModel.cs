using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Models.CommonModels
    {
    public class BaseServiceModel<TKey>
        {

        public BaseServiceModel ()
            {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.IsEdited = false;
            }

        public TKey Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsEdited { get; set; }

        public DateTime? EditedOn { get; set; }
        }
    }
