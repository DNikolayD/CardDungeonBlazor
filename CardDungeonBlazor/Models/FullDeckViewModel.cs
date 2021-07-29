﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDungeonBlazor.Models
{
    public class FullDeckViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string CreatedOn { get; set; }

        public int NumberOfCards { get; set; }
    }
}
