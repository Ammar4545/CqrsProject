using AutoMapper;
using CqrsProject.Entities.Dbset;
using CqrsProject.Entities.DTO.Responses;

namespace CqrsProject.Api.MappingProfile
{
    public class DomainToResponse:Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                ;

            CreateMap<Driver, GetDriverResponse>()
                .ForMember(dest => dest.DriverId, option => option.MapFrom(src => src.Id))
                .ForMember(dest=>dest.FullName,option=>option.MapFrom(src=>$"{src.FirstName} {src.LastName}"));
                ;
            //CreateMap<Driver, GetDriverResponse>()
            //    .ForMember(dest => dest.DriverId, option => option.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.FullName, option => option.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            ;
        }
        
    }
}
