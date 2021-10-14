using System.ComponentModel.DataAnnotations;

namespace CardDungeonBlazor.Models
    {
    public class ImageViewModel : BaseViewModel<string>
        {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Img { get; set; }

        [Required]
        public UserViewModel UploadedByUser { get; set; }
        }
    }
