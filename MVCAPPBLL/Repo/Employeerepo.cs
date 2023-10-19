using MVCAPPBLL.interfaces;
using MVCAPPDAL.Context;
using MVCAPPDAL.Models;
using System;
using System.Linq;

namespace MVCAPPBLL.Repo
{
	public class Employeerepo : GenaricRipo<Employee>, IEmployeerepo
	{
		private readonly MVCAPPDbContext _dbContext;

		public Employeerepo(MVCAPPDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<Employee> GetEmployeeByAddress(string address)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Employee> GetEmployessByName(string name)
		=> _dbContext.Employees.Where(E => E.Name.ToLower().ToLower().Contains(name.ToLower()));
	}
}
