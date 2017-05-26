using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomAuthMiddlewareWebApp.Models.AccountViewModels;
using System.Security.Principal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomAuthMiddlewareWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View(new SignInViewModel());
        }

        //[HttpPost]
        //public IActionResult SignIn(SignInViewModel vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(vm);
        //    }

        //    if(vm.Username!="atorris" || vm.Password != "password")
        //    {
        //        return View(vm);
        //    }

        //    //HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance", new System.Security.Claims.ClaimsPrincipal(new GenericIdentity(vm.Username)));
        //    HttpContext.User = new System.Security.Claims.ClaimsPrincipal(new GenericIdentity(vm.Username));
        //    HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance", new System.Security.Claims.ClaimsPrincipal(new GenericIdentity(vm.Username)));


        //    Console.WriteLine("Is authenticated: ${context.User.Identity.IsAuthenticated}");

        //    return RedirectToAction("Index", "Home");
        //}
    }
}