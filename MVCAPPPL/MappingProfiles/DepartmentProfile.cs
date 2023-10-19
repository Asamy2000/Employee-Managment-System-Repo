using AutoMapper;
using MVCAPPDAL.Models;
using MVCPL.Models;

namespace MVCPL.MappingProfiles
{
	public class DepartmentProfile : Profile
	{
		public DepartmentProfile()
		{
			CreateMap<DepartmentVM, Department>().ReverseMap();
		}
	}
}
