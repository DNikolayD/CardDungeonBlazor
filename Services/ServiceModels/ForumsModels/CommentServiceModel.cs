﻿namespace Services.ServiceModels.ForumsModels
    {
    public class CommentServiceModel
        {
        public string Text { get; set; }

        public string Image { get; set; }

        public int Likes { get; set; }

        public string Username { get; set; }

        public string CreatedOn { get; set; }
        }
    }