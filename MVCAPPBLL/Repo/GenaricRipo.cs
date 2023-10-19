using MVCAPPBLL.interfaces;
using MVCAPPDAL.Context;
using MVCAPPDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCAPPBLL.Repo
{
	public class GenaricRipo<T> : IGenaricRepo<T> where T : class
	{
		private readonly MVCAPPDbContext _dbContext;
		public GenaricRipo(MVCAPPDbContext dbContext) // Ask clr to create an obj from dbcontext
		{
			//_dbContext = /*new EFGDbContext();*/
			_dbContext = dbContext;
		}
		public async Task Add(T item)
		   => await _dbContext.Set<T>().AddAsync(item);

		public void Delete(T item)
		   => _dbContext.Set<T>().Remove(item);


		public async Task<T> Get(int id)
			=> await _dbContext.Set<T>().FindAsync(id);

		public async Task<IEnumerable<T>> GetAll()
		{
			if (typeof(T) == typeof(Employee))
				return (IEnumerable<T>)await _dbContext.Employees.Include(E => E.Department).ToListAsync();
			else
				return await _dbContext.Set<T>().ToListAsync();
		}


		public void Update(T item)
			=> _dbContext.Set<T>().Update(item);

	}
}
