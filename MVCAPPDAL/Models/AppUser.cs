using Microsoft.AspNetCore.Identity;

namespace MVCAPPDAL.Models
{
	public class AppUser : IdentityUser
	{
		public string Fname { get; set; }
		public string Lname { get; set; }
		public bool IsAgree { get; set; }
	}
}
