using MVCAPPDAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
	public class EmployeeVM
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is Required!!")]
		[MaxLength(50, ErrorMessage = "Max length is 50")]
		[MinLength(5, ErrorMessage = "Max length is 5")]
		public string Name { get; set; }
		[Range(22, 60)]
		public int? Age { get; set; }
		[RegularExpression("^\\d+-[A-Za-z]+\\-[A-Za-z]+\\-[A-Za-z]+$",
			ErrorMessage = "Address must be like 123-Street-City-Country")]
		public string Address { get; set; }

		public decimal Salary { get; set; }
		public bool IsActive { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		[Phone]
		public string Phone { get; set; }
		public IFormFile Image { get; set; }
		public string ImageName { get; set; }
		public DateTime HireDate { get; set; }
		//[ForeignKey("Department")]
		public int? DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
