namespace Services.ServiceModels.ForumsModels
    {
    public class AddPostServiceModel
        {
        public string Title { get; set; }

        public string TextContent { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }

        public int Likes { get; set; }

        public string CategoryId { get; set; }
        }
    }
