using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CommonModels;

namespace ServiceLibrary.Models.UserModels
    {
    public class RoleServiceModel : BaseServiceModel<string>
        {
        public string Name { get; set; }
        }
    }
