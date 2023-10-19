using MVCAPPDAL.Models;
using MVCPL.Helpers;
using MVCPL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MVCAPPPL.Helpers;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using System.Linq;

namespace MVCPL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSettings _emailSettings;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager , IEmailSettings emailSettings)
        {
			_userManager = userManager;
			_signInManager = signInManager;
            _emailSettings = emailSettings;
        }
		#region Register
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
			if (ModelState.IsValid)
			{
				var user = new AppUser()
				{
					Fname = registerVM.Fname,
					Lname = registerVM.Lname,
					UserName = registerVM.Email.Split('@')[0],
					Email = registerVM.Email,
					IsAgree = registerVM.IsAgree

				};
				var result = await _userManager.CreateAsync(user, registerVM.Password); //[HashedPassword]
																						//result stored to check if Succeeded or not
				if (result.Succeeded)
				{
					return RedirectToAction(nameof(Login));
				}
				else
				{
					foreach (var error in result.Errors) //each result have a collection of errors
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}
			return View(registerVM);
		} 
		#endregion

		#region Register - Role
		//   public IActionResult AddAdmin()
		//   {
		//       return View("Register");
		//   }

		//   [HttpPost]
		//   public async Task<IActionResult> AddAdmin(RegisterVM registerVM)
		//   {
		//       if (ModelState.IsValid)
		//       {
		//           var user = new AppUser()
		//           {
		//               Fname = registerVM.Fname,
		//               Lname = registerVM.Lname,
		//               UserName = registerVM.Email.Split('@')[0],
		//               Email = registerVM.Email,
		//               IsAgree = registerVM.IsAgree

		//           };
		//           var result = await _userManager.CreateAsync(user, registerVM.Password); //[HashedPassword]
		//           //result stored to check if Succeeded or not
		//           if (result.Succeeded)
		//           {
		//await _userManager.AddToRoleAsync(user, "Admin");
		//               return RedirectToAction(nameof(Login));
		//           }
		//           else
		//           {
		//               foreach (var error in result.Errors) //each result have a collection of errors
		//               {
		//                   ModelState.AddModelError(string.Empty, error.Description);
		//               }
		//           }
		//       }
		//       return View("Register", registerVM);
		//   } 
		#endregion

		#region Login

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(loginVM.Email);
				if (user is not null)
				{
					var flag = await _userManager.CheckPasswordAsync(user, loginVM.Password);
					if (flag)
					{
						await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RemeberMe, false);
						return RedirectToAction("Index", "Home");
					}
					ModelState.AddModelError(string.Empty, "Invalid Password");
				}
				ModelState.AddModelError(string.Empty, "Email is mot Exist");
			}
			return View(loginVM);
		}
		#endregion

		#region signOut
		public new async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		} 
		#endregion

		#region Forget Password

		public IActionResult ForgetPassword()
		{
			return View();
		}

		public async Task<IActionResult> SendEmail(ForgetPasswordVM forgetPasswordVM)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(forgetPasswordVM.Email);
				if (user is not null)
				{
					var token = await _userManager.GeneratePasswordResetTokenAsync(user);
					var passwordResetLink = Url.Action("ResetPassword", "Account", new {email = user.Email,token},Request.Scheme);
					var email = new Email()
					{
						Subject = "Reset Password",
						To = user.Email,
						Body = passwordResetLink
					};
					_emailSettings.SendEmail(email);
					//EmailSettings.SendEmail(email);
					return RedirectToAction(nameof(checkUrInbox));
				}
				ModelState.AddModelError(string.Empty, "Email is not Exist");
			}
			return View("ForgetPassword");
		}


		public IActionResult checkUrInbox()
		{
			return View();
		}


		#endregion

		#region Reset Password

		public IActionResult ResetPassword(string email,string token)
		{
			TempData["email"]= email; TempData["token"]= token;
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
		{
			if (ModelState.IsValid)
			{
				string email = TempData["email"] as string;
				string token = TempData["token"] as string;
				var user = await _userManager.FindByEmailAsync(email);
				if (user is not null)
				{
					var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
					if (result.Succeeded)
					{
						return RedirectToAction(nameof(Login));
					}
					foreach (var error in result.Errors)
						ModelState.AddModelError(string.Empty, error.Description);
				}
				ModelState.AddModelError(string.Empty, "User Not Exist");
				
			}
			return View(model);
		}

		#endregion

		#region External Login - Google
		public IActionResult GoogleLogin()
		{
			var prop = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
			return Challenge(prop, GoogleDefaults.AuthenticationScheme);
		}

		public async Task<IActionResult> GoogleResponse()
		{
			var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

			if (result.Succeeded)
			{
				var claims = result.Principal.Claims.Select(claim => new
				{
					claim.Issuer,
					claim.OriginalIssuer,
					claim.Type,
					claim.Value
				});

				return Json(claims);
			}
			else if (result.Failure != null)
			{
				// Handle authentication failure
				return BadRequest("Authentication failed: " + result.Failure.Message);
			}
			else
			{
				// Handle the case where authentication result is not successful but not an error.
				// This may indicate that the user is not authenticated.
				return Unauthorized("User is not authenticated.");
			}
		}
        #endregion

    }
}
