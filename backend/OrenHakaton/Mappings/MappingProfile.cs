namespace OrenHakaton
{
    using AutoMapper;

    using OrenHakaton.Models;
    using OrenHakaton.Models.DtoModels;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Specialties, SpecialtiesDto>();
            CreateMap<SpecialtiesDto, Specialties>();

            CreateMap<UsersDto, Users>()
                .ForMember(opt => opt.Apartments, dto => dto.MapFrom(src => src.Apartments));
            CreateMap<Users, UsersDto>()
                .ForMember(dto => dto.Apartments, opt => opt.MapFrom(src => src.Apartments));

            CreateMap<Requests, RequestsDto>()
                .ForMember(opt => opt.ManagementCompanies, dto => dto.MapFrom(src => src.ManagementCompanies));
            CreateMap<RequestsDto, Requests>()
                .ForMember(dto => dto.ManagementCompanies, opt => opt.MapFrom(src => src.ManagementCompanies));

            CreateMap<Houses, HousesDto>()
                .ForMember(opt => opt.Apartments, dto => dto.MapFrom(src => src.Apartments));
            CreateMap<HousesDto, Houses>()
                .ForMember(dto => dto.Apartments, opt => opt.MapFrom(src => src.Apartments));

            CreateMap<ManagementCompanies, ManagementCompaniesDto>()
                .ForMember(opt => opt.Houses, dto => dto.MapFrom(src => src.Houses));
            CreateMap<ManagementCompaniesDto, ManagementCompanies>()
                .ForMember(dto => dto.Houses, opt => opt.MapFrom(src => src.Houses));

            CreateMap<EmployeesMCDto, EmployeesMC>()
                .ForMember(opt => opt.Specialties, dto => dto.MapFrom(src => src.Specialties))
                .ForMember(opt => opt.ManagementCompanies, dto => dto.MapFrom(src => src.ManagementCompanies));
            CreateMap<EmployeesMC, EmployeesMCDto>()
                .ForMember(dto => dto.Specialties, opt => opt.MapFrom(src => src.Specialties))
                .ForMember(dto => dto.ManagementCompanies, opt => opt.MapFrom(src => src.ManagementCompanies));

            CreateMap<Meetings, MeetingsDto>()
                .ForMember(opt => opt.Houses, dto => dto.MapFrom(src => src.Houses))
                .ForMember(opt => opt.ManagementCompanies, dto => dto.MapFrom(src => src.ManagementCompanies));
            CreateMap<MeetingsDto, Meetings>()
                .ForMember(dto => dto.Houses, opt => opt.MapFrom(src => src.Houses))
                .ForMember(dto => dto.ManagementCompanies, opt => opt.MapFrom(src => src.ManagementCompanies));
        }
    }
}
