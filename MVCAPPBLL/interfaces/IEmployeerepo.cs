using MVCAPPDAL.Models;
using System.Linq;

namespace MVCAPPBLL.interfaces
{
	public interface IEmployeerepo : IGenaricRepo<Employee>
	{
		IQueryable<Employee> GetEmployeeByAddress(string address);

		IQueryable<Employee> GetEmployessByName(string name);
	}
}
