using System;
using System.Threading.Tasks;

namespace MVCAPPBLL.interfaces
{
	public interface IunitOfWork : IDisposable
	{
		public IEmployeerepo Employeerepo { get; set; }
		public IDepartmentrepo Departmentrepo { get; set; }

		Task<int> Complete();
	}
}
