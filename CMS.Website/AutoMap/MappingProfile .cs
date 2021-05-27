using AutoMapper;
using CMS.Data.ModelDTO;
using CMS.Data.ModelEntity;

namespace CMS.Website.AutoMap
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Account
            CreateMap<AspNetUsers, AspNetUsersDTO>().ReverseMap();
            CreateMap<AspNetUserProfiles, AspNetUserProfilesDTO>().ReverseMap();
            CreateMap<AspNetUserRoles, AspNetUserRolesDTO>().ReverseMap();
            CreateMap<AspNetUserInfo, AspNetUserInfoDTO>().ReverseMap();
            //Article
          

        }
    }
}
