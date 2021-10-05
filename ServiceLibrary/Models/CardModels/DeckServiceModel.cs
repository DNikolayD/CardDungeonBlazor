using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data.Models.Common;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.UserModels;
using static DataConstraints.Deck;

namespace ServiceLibrary.Models.CardModels
    {
    public class DeckServiceModel : BaseServiceModel<string>
        {
        public DeckServiceModel ()
            {
            this.Cards = new List<CardServiceModel>();
            this.Users = new List<UserServiceModel>();
            }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DeckType DeckType { get; set; }

        [Required]
        public List<CardServiceModel> Cards { get; set; }

        [Required]
        public UserServiceModel CreatedByUser { get; set; }

        public virtual List<UserServiceModel> Users { get; set; }
        }
    }
