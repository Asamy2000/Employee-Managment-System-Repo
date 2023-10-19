using AutoMapper;
using MVCAPPDAL.Models;
using MVCPL.Models;

namespace MVCPL.MappingProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserVM>().ReverseMap();
        }
    }
}
