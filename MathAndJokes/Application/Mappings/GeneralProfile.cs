﻿using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands


            #endregion

            #region Queries

            CreateMap<Joke, JokeDto>();

            #endregion
        }
    }
}