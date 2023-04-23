using AutoMapper;

namespace AutoMapperAndDTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<SuperHero, SuperHeroDto>();
            CreateMap<SuperHeroDto, SuperHero>();
        }
    }
}
