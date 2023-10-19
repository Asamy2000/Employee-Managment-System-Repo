using AutoMapper;
using MVCPL.Models;
using Microsoft.AspNetCore.Identity;

namespace MVCPL.MappingProfiles
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleVM,IdentityRole>().ForMember(d => d.Name,O => O.MapFrom(s => s.RoleName)).ReverseMap();
        }
    }
}
