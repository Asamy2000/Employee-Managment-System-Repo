using MVCAPPDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
	public class DepartmentVM
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Code is required !")]
		public string Code { get; set; }
		[Required(ErrorMessage = "Name is required !")]
		public string Name { get; set; }
		public DateTime DateOfCreation { get; set; }
		public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
	}
}
