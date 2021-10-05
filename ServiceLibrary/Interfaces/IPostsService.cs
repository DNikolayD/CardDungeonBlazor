using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.ForumModels;

namespace ServiceLibrary.Interfaces
    {
    public interface IPostsService
        {
        bool Add ( PostServiceModel postServiceModel );

        List<PostServiceModel> Show ( string categoryId );

        bool Edit ( PostServiceModel postServiceModel );

        bool Delete ( string postId );
        }
    }
