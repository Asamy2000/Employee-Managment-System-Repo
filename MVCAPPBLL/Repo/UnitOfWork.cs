using MVCAPPBLL.interfaces;
using MVCAPPDAL.Context;
using System.Threading.Tasks;

namespace MVCAPPBLL.Repo
{
	public class UnitOfWork : IunitOfWork
	{
		private readonly MVCAPPDbContext _dbContext;

		public IEmployeerepo Employeerepo { get; set; }
		public IDepartmentrepo Departmentrepo { get; set; }

		public UnitOfWork(MVCAPPDbContext dbContext)
		{
			Employeerepo = new Employeerepo(dbContext);
			Departmentrepo = new Departmentrepo(dbContext);
			_dbContext = dbContext;
		}

		public async Task<int> Complete()
		 => await _dbContext.SaveChangesAsync();

		public void Dispose()
		=> _dbContext.Dispose();
	}
}
