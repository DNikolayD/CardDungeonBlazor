using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models.CommonModels;

namespace ServiceLibrary.Models.CardModels
    {
    public class CardTypeServiceModel : BaseServiceModel<int>
        {
        public string Name { get; set; }
        }
    }
