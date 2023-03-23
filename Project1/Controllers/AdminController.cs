using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Repository;
using NuGet.Protocol.Plugins;



namespace Project1.Controllers {
    public class AdminController : Controller {
        private readonly IAdminRepository _Repo;

        public AdminController(IAdminRepository Repo)
        {
            _Repo = Repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string Returnurl)
        {
            ViewBag.Returnurl = Returnurl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (admin.username.ToLower() == "admin" && admin.password == "admin")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,admin.username),
                        new Claim(ClaimTypes.Role,"Admin")
                    };
                    var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal user = new ClaimsPrincipal(ClaimsIdentity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        //ExpiresUtc= DateTime.UtcNow.AddMinutes(60),
                        AllowRefresh = true,
                    }
                    );
                    if (HttpContext.Request.Query["Returnurl"].ToString() != "")
                        return View();
                    else
                        return RedirectToAction("Index", "Admin");
                }

                //ViewBag.Msg = "Invalid Credentials";
                ModelState.AddModelError(string.Empty, "Invalid username and password");
            }
            return View();

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }






}