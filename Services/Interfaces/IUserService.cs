using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ServiceModels.UserModels;

namespace Services.Interfaces
    {
    public interface IUserService
        {
        Show GetShow ( string userName );

        void Edit ( Show user );
        }
    }
