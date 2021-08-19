using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodilizer_Group35.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodilizer_Group35.Controllers
{
    public class LoginController : Controller
    {
        private readonly foodilizerContext _context;
        public LoginController(foodilizerContext context)
        {
            _context = context;
        }

        //View login page
        // GET: Login
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("user_id", -1);
            HttpContext.Session.SetString("user_type", "");
            //HttpContext.Session.SetString("email", "");
            return View();
        }

        //Login process
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginMember([Bind("email,password")] User user)
        {
            try
            {
                user.ShaEnc();
                var uuser = await _context.Users.FirstOrDefaultAsync(e => e.email == user.email && e.Password == user.password /*&& e.User_status == 1*/);

                if (uuser == null)
                {
                    TempData["Error"] = "Invalid login credentials";
                    return RedirectToAction("Index");
                }

                HttpContext.Session.SetString("UName", uuser.UserName);
                HttpContext.Session.SetString("UEmail", uuser.UserEmail);
                HttpContext.Session.SetInt32("UID", uuser.UserId);
                HttpContext.Session.SetString("UType", (bool)uuser.UserType ? "C" : "A");

                if ((bool)uuser.UserType)
                {
                    return RedirectToAction("Index", "Home");
                }
                else return RedirectToAction("Index", "Admin");
            }
            catch (Exception)
            {
                TempData["Error"] = "Error occured during login process. Please try again.";
                return RedirectToAction("Index");
            }
        }

        
    }
}
