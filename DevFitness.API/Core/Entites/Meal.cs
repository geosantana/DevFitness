﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Core.Entites
{
    public class Meal : BaseEntity
    {
        public Meal(string description, int calories, DateTime date, int userId) : base()
        {
            Description = description;
            Calories = calories;
            Date = date;
            UserId = userId;
        }

        public string Description { get; private set; }
        public int Calories { get; private set; }
        public DateTime Date { get; private set; }

        public int UserId { get; private set; }

        public void Update(string desciption, int calories, DateTime date)
        {
            Description = desciption;
            Calories = calories;
            Date = date;
        }
    }
}
