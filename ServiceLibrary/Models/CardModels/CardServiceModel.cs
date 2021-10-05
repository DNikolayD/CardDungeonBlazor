using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.UserModels;
using static DataConstraints.Card;

namespace ServiceLibrary.Models.CardModels
    {
    public class CardServiceModel : BaseServiceModel<string>
        {
        public CardServiceModel ()
            {
            this.Decks = new List<DeckServiceModel>();
            }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public CardTypeServiceModel CardType { get; set; }

        [Required]
        [Range(MinValue, MaxValue)]
        public int Value { get; set; }

        [Required]
        [Range(MinCost, MaxCost)]
        public int Cost { get; set; }

        public int Duration { get; set; }

        [Required]
        public ImageServiceModel Image { get; set; }

        public List<DeckServiceModel> Decks { get; set; }

        [Required]
        public UserServiceModel CreatedByUser { get; set; }
        }
    }
