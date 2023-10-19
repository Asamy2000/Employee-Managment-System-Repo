using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
	public class ForgetPasswordVM
	{
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
	}
}
