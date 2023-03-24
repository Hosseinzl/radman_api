using Application.Dto;
using Application.Model;
using AutoMapper;

namespace PokemonReviewApi.Helper
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles() 
        {
            CreateMap<UserDto, User>();
            //CreateMap<MetaDataType, MetaDataTypeDto>();
        }
    }
}
