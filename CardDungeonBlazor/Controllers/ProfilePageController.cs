using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Services.Interfaces;

namespace CardDungeonBlazor.Controllers
    {
    public class ProfilePageController : ComponentBase
        {
        [Inject]
        protected IUserService Service { get; set; }
        }
    }
