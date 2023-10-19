using AutoMapper;
using MVCAPPDAL.Models;

using MVCPL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MVCPL.Controllers
{
    [Authorize("Admin")]
	public class UserMangerController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserMangerController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager , IMapper mapper , RoleManager<IdentityRole> roleManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }



		public async Task<IActionResult> Index(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				var users = await _userManager.Users.Select(U => new UserVM
				{
					Id = U.Id,
					FName = U.Fname,
					LName = U.Lname,
					Email = U.Email,
					PhoneNumber = U.PhoneNumber,
					Roles = _userManager.GetRolesAsync(U).Result

				}).ToListAsync();
				return View(users);
			}
			else
			{
				var user = await _userManager.FindByEmailAsync(email);
				var mappedUser = new UserVM()
				{
					Id = user.Id,
					FName = user.Fname,
					LName = user.Lname,
					Email = user.Email,
					PhoneNumber = user.PhoneNumber,
					Roles = _userManager.GetRolesAsync(user).Result

				};

				return View(new List<UserVM>() { mappedUser });
			}
		}




        //Details Action

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();
			var User = await _userManager.FindByIdAsync(id);
            if (User == null)
                return NotFound();
            var mappedUser = _mapper.Map<AppUser, UserVM>(User);
            return View(viewName, mappedUser);
        }



        #region EDIT

        public async Task<IActionResult> Edit(string id)
        {

            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, UserVM userVM)
        {
            //for security from hidden input
            if (id != userVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedUser = await _userManager.FindByIdAsync(id);
                    if (mappedUser is not null)
                    {
                        mappedUser.Fname = userVM.FName;
                        mappedUser.Lname = userVM.LName;
                        mappedUser.PhoneNumber = userVM.PhoneNumber;
                        //mappedUser.Email = userVM.Email;
                        //mappedUser.SecurityStamp =Guid.NewGuid().ToString();
                        await _userManager.UpdateAsync(mappedUser);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "please fill all cells");
                    }
                    
                    
                    
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(userVM);
        }


        #endregion

        #region Delete

        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            
            try
            {
                var User = await _userManager.FindByIdAsync(id);
                await _userManager.DeleteAsync(User);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Error", "Home");
            }

        }


        #endregion

        public IActionResult AssignRoles()
        {
           var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles.Select(r => new SelectListItem(r.Name, r.Name));
            return  View();
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoles(UserVM model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            var rolesToAdd = model.Roles.Except(await _userManager.GetRolesAsync(user));
            var rolesToRemove = (await _userManager.GetRolesAsync(user)).Except(model.Roles);

            await _userManager.AddToRolesAsync(user, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("Index");
        }
    }
}
