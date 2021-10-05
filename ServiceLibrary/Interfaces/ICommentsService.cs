using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.ForumModels;

namespace ServiceLibrary.Interfaces
    {
    public interface ICommentsService
        {
        bool Add ( CommentServiceModel commentServiceModel );

        List<CommentServiceModel> Show ( string postId );

        bool Edit ( CommentServiceModel commentServiceModel );

        bool Delete ( string commentId );
        }
    }
