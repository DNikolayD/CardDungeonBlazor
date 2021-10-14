using System.Collections.Generic;
using CardDungeonBlazor.Areas.Cards.Models;
using CardDungeonBlazor.Areas.Forum.Models;

namespace CardDungeonBlazor.Models
    {
    public class UserViewModel : BaseViewModel<string>
        {
        public string Name { get; set; }
        public ImageViewModel ProfilePhoto { get; set; }

        public RoleViewModel Role { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public List<CardViewModel> CreatedCards { get; set; }

        public List<DeckViewModel> CreatedDecks { get; set; }

        public List<PostViewModel> Posts { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public List<CommentViewModel> LikedPosts { get; set; }

        public List<CommentViewModel> LikedComments { get; set; }
        }
    }
