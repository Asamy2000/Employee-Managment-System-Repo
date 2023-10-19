using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
	public class LoginVM
	{
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RemeberMe { get; set; }
	}
}
