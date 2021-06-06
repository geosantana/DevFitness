﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Models.inputModels
{
    public class CreateuserInputModel
    {
        public string FullName { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
