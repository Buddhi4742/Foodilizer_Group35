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
                var userDetails = await _context.Users.FirstOrDefaultAsync(e => e.Email == user.Email && e.Password == user.Password /*&& e.User_status == 1*/);

                if (userDetails == null)
                {
                    TempData["Error"] = "Invalid login credentials";
                    return RedirectToAction("Index");
                }

                if (userDetails != null)
                {
                    HttpContext.Session.SetString("UName", userDetails.UserName);
                    HttpContext.Session.SetString("UEmail", userDetails.UserEmail);
                    HttpContext.Session.SetInt32("UID", userDetails.UserId);
                    HttpContext.Session.SetString("UType", (bool)userDetails.UserType ? "C" : "A");

                    if ((bool)userDetails.UserType)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else return RedirectToAction("Index", "Admin");
                }
                
            }
            catch (Exception)
            {
                TempData["Error"] = "Error occured during login process. Please try again.";
                return RedirectToAction("Index");
            }
        }

        
    }
}
