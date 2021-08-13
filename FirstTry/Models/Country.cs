﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTry.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MyProperty { get; set; }
        public List<State> States { get; set; }
    }
}
