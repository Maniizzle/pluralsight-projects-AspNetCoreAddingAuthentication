using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using WishList.Models.AccountViewModels;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            { var password = viewModel.Password;
                ApplicationUser user = new ApplicationUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                foreach (var Error in result.Errors)
                {
                    ModelState.AddModelError("Password", Error.Description);
                }
            }

            return View(viewModel);
        }
    }
}
