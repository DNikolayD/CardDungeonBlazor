using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DataConstraints.Card;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class AddCardFormModel
        {
        public AddCardFormModel ()
            {
            this.CardTypes = new List<CardTypeViewModel>();
            }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CardTypeId { get; set; }

        public virtual List<CardTypeViewModel> CardTypes { get; set; }

        [Range(MinValue, MaxValue)]
        public int Value { get; set; }

        [Range(MinCost, MaxCost)]
        public int Cost { get; set; }

        }
    }
