using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using MyCarbonFootprintCalculator.Models;
using MyCarbonFootprintCalculator.Models.ViewModel;
using LoginModel = MyCarbonFootprintCalculator.Models.ViewModel.LoginModel;

namespace MyCarbonFootprintCalculator.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<User> UserMgr { get; }
        private SignInManager<User> SignInMgr { get; }
        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register userModel)
        {
            if (ModelState.IsValid)
            {

                var user = new User()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.Email,
                    Email = userModel.Email,
                };

                var result = await UserMgr.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {

                    await SignInMgr.SignOutAsync();
                    if ((await SignInMgr.PasswordSignInAsync(user.UserName, userModel.Password, false, false))
                        .Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    ViewBag.Result = "Incorrect Password format";
                    ViewBag.Result1 = "\u2022 At least one Uppercase letter";
                    ViewBag.Result2 = "\u2022 At least one Lowercase letter";
                    ViewBag.Result3 = "\u2022 At least one number";
                    ViewBag.Result4 = "\u2022 At least one special character eg. !@#$%^&*";
                    return View();
                }

            }

            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {

            var result = await SignInMgr.PasswordSignInAsync(login.UserName, login.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "Incorrect UserName/Password combination";
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
    

