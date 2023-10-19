using AutoMapper;
using MVCAPPDAL.Models;
using MVCPL.Models;

namespace MVCPL.MappingProfiles
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<EmployeeVM, Employee>().ReverseMap();
		}
	}
}
