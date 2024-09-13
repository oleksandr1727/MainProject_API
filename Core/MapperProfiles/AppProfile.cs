using AutoMapper;
using Core.Dtos;
using Data.Entitites;

namespace Core.MapperProfiles
{
    public class AppProfile: Profile
    {
        public AppProfile() 
        {
            CreateMap<CreatePetDto, Pet>();
            CreateMap<PetDto, Pet>().ReverseMap();
            CreateMap<EditPetDto, Pet>();
        }
    }
}
