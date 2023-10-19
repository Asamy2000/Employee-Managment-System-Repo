using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
    public class ResetPasswordVM
    {
		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Not matched Password")]
        public string ConfirmPassword { get; set; }
    }
}
