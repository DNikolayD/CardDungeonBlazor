using Services.ServiceModels.ForumsModels;

namespace Services.Interfaces
    {
    public interface IPostsService
        {
        public string GetUserId ( string name );

        AllPostsServiceModel GetPosts ( string id );

        void Delete ( string id );

        void AddPost ( AddPostServiceModel model );

        AddPostServiceModel GetPostsForm ( string id );

        void Edit ( AddPostServiceModel model, string id );

        FullPostServiceModel GetFullPost ( string id );

        void AddComment ( string id, CommentServiceModel model );
        }
    }
