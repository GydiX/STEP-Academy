using AutoMapper;
using users_wf.DTOs;
using users_wf.Models;

namespace users_wf.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // UserDTO -> User
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName.ToLower()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower()))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}
