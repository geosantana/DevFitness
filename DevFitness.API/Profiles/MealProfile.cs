using AutoMapper;
using DevFitness.API.Core.Entites;
using DevFitness.API.Models.inputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Profiles
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<MealProfile, MealProfile>();
            CreateMap<CreateMealInputModel, Meal>();
        }
    }
}
