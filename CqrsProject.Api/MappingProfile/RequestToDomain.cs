using AutoMapper;
using CqrsProject.Entities.Dbset;
using CqrsProject.Entities.DTO.Requests;

namespace CqrsProject.Api.MappingProfile
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateDriverAchievementRequest, Achievement>().
                ForMember(dest => dest.Status, option => option.MapFrom(src => 1)).
                ForMember(dest => dest.AddedDate, option => option.MapFrom(src => DateTime.UtcNow)).
                ForMember(dest => dest.UpdatedDate, option => option.MapFrom(src => DateTime.UtcNow))
                ;
            CreateMap<UpdateDriverAchievementRequest, Achievement>().
                ForMember(dest => dest.UpdatedDate, option => option.MapFrom(src => DateTime.UtcNow))
                ;

            CreateMap<CreateDriverRequest, Driver>().
                ForMember(dest => dest.Status, option => option.MapFrom(src => 1))
                ;
            CreateMap<UpdateDriverRequest, Driver>().
                ForMember(dest => dest.UpdatedDate, option => option.MapFrom(src => DateTime.UtcNow))
                ;

        }
    }
}
