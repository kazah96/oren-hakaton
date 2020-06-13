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

            CreateMap<EmployeesMCDto, EmployeesMC>().ForMember(opt => opt.Specialties, dto => dto.MapFrom(src => src.Specialties));
            CreateMap<EmployeesMC, EmployeesMCDto>().ForMember(dto => dto.Specialties, opt => opt.MapFrom(src => src.Specialties)); ;

            CreateMap<Specialties, SpecialtiesDto>();
            CreateMap<SpecialtiesDto, Specialties>();

            CreateMap<Meetings, MeetingsDto>();
            CreateMap<MeetingsDto, Meetings>();
        }
    }
}
