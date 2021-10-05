using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.UserModels;

namespace ServiceLibrary.Interfaces
    {
    public interface IUserService
        {
        UserServiceModel Show ( string userName );

        bool Edit ( UserServiceModel userServiceModel );
        }
    }
