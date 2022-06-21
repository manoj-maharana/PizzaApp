﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Data.Interface.Model
{
    public class PizzaType
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public int Type { get; set; }
        public string Name { get; set; } = null!;

    }
}
