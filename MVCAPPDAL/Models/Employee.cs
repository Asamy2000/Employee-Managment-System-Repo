using System;
using System.ComponentModel.DataAnnotations;

namespace MVCAPPDAL.Models
{
	public class Employee
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]

		public string Name { get; set; }

		public int? Age { get; set; }
		public string Address { get; set; }
		[DataType(DataType.Currency)]
		public decimal Salary { get; set; }
		public bool IsActive { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }
		public DateTime HireDate { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now;
		//[ForeignKey("Department")]
		public string ImageName { get; set; }
		public int? DepartmentId { get; set; }
		public Department Department { get; set; }

	}
}
