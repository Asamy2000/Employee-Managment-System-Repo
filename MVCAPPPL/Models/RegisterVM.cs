using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
	public class RegisterVM
	{
		public string Fname { get; set; }
		public string Lname { get; set; }
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "Confirm Password is Required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Not matched Password")]
		public string ConfirmPassword { get; set; }
		public bool IsAgree { get; set; }
	}
}
