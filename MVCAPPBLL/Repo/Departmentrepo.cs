using MVCAPPBLL.interfaces;
using MVCAPPDAL.Context;
using MVCAPPDAL.Models;

namespace MVCAPPBLL.Repo
{
	//this class has a composesion with dbcontext
	// it has a dbcontext
	public class Departmentrepo : GenaricRipo<Department>, IDepartmentrepo
	{

		public Departmentrepo(MVCAPPDbContext dbContext) : base(dbContext) // Ask clr to create an obj from dbcontext
		{
			//_dbContext = /*new EFGDbContext();*/

		}

	}
}
