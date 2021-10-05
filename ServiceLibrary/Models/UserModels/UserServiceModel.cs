using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDungeonBlazor.Data.Models.User;
using ServiceLibrary.Models.CardModels;
using ServiceLibrary.Models.CommonModels;
using ServiceLibrary.Models.ForumModels;

namespace ServiceLibrary.Models.UserModels
    {
    public class UserServiceModel : BaseServiceModel<string>
        {
        public string Name { get; set; }
        public ImageServiceModel ProfilePhoto { get; set; }

        public RoleServiceModel Role { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public List<CardServiceModel> CreatedCards { get; set; }

        public List<DeckServiceModel> CreatedDecks { get; set; }

        public List<PostServiceModel> Posts { get; set; }

        public List<CommentServiceModel> Comments { get; set; }

        public List<PostServiceModel> LikedPosts { get; set; }

        public List<CommentServiceModel> LikedComments { get; set; }
        }
    }
