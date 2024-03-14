using Application.DTOs;
using Application.Features.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands

            CreateMap<CreateJokes, Joke>();

            #endregion

            #region Queries

            CreateMap<Joke, JokeDto>();

            #endregion
        }
    }
}