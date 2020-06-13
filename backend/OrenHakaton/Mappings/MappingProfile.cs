namespace OrenHakaton
{
    using AutoMapper;

    using OrenHakaton.Models;
    using OrenHakaton.Models.DtoModels;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsersDto, Users>();
            CreateMap<Users, UsersDto>();

            CreateMap<Requests, RequestsDto>();
            CreateMap<RequestsDto, Requests>();

            CreateMap<Houses, HousesDto>();
            CreateMap<HousesDto, Houses>();
        }
    }
}
