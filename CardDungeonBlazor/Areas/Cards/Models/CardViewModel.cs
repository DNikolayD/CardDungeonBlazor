using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CardDungeonBlazor.Models;
using static DataConstraints.Card;

namespace CardDungeonBlazor.Areas.Cards.Models
    {
    public class CardViewModel : BaseViewModel<string>
        {

        public CardViewModel ()
            {
            this.CardType = new();
            this.Image = new();
            this.Decks = new();
            this.CreatedByUser = new();
            }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public CardTypeViewModel CardType { get; set; }

        [Required]
        [Range(MinValue, MaxValue)]
        public int Value { get; set; }

        [Required]
        [Range(MinCost, MaxCost)]
        public int Cost { get; set; }

        public int Duration { get; set; }

        [Required]
        public ImageViewModel Image { get; set; }

        public List<DeckViewModel> Decks { get; set; }

        [Required]
        public UserViewModel CreatedByUser { get; set; }
        }
    }
