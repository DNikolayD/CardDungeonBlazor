using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConstraints
    {
    public class Post
        {
        public const int TitleMinLength = 1;

        public const int TitleMaxLength = 20;

        public const int TextMinLength = 1;

        public const int TextMaxLength = 400;
        }
    }
