using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFI_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DFI_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegistrationViewModel model)
        {

            if (ModelState.IsValid)
            {
                var users = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(users, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(users, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }

            }

            return View("Registration");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var res = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (res.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError("", "Invalid Login");


            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}