using AutoMapper;
using Csharp_WebAPI_Assignment3.DTOs.CharacterDTOs;
using Csharp_WebAPI_Assignment3.Models;

namespace Csharp_WebAPI_Assignment3.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterReadDTO>();
            CreateMap<CharacterCreateDTO, Character>().ReverseMap();
            CreateMap<CharacterUpdateDTO, Character>().ReverseMap();
        }
    }
}
