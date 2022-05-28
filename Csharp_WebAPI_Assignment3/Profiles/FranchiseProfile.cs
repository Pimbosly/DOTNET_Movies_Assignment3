using AutoMapper;
using Csharp_WebAPI_Assignment3.DTOs.FranchiseDTOs;
using Csharp_WebAPI_Assignment3.Models;

namespace Csharp_WebAPI_Assignment3.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseReadDTO>();
            CreateMap<FranchiseCreateDTO, Franchise>().ReverseMap();
            CreateMap<FranchiseUpdateDTO, Franchise>().ReverseMap();
        }
    }
}
