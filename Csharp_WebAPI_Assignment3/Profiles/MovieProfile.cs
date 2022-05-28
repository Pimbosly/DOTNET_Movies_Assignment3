using AutoMapper;
using Csharp_WebAPI_Assignment3.DTOs.MovieDTOs;
using Csharp_WebAPI_Assignment3.Models;

namespace Csharp_WebAPI_Assignment3.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDTO>();
            CreateMap<MovieCreateDTO, Movie>().ReverseMap();
            CreateMap<MovieUpdateDTO, Movie>().ReverseMap();
        }
    }
}
