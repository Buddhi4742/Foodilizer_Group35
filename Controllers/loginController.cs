using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Foodilizer_Group35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodilizer_Group35.Controllers
{
    public class LoginController : Controller



    {
        private readonly foodilizerContext _context;

        public LoginController(foodilizerContext context)
        {
            _context = context;
        }


        //Login process
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginMember([Bind("UserEmail,UserPass")] TUser tUser)
        {
            try
            {
                tUser.ShaEnc();
                var user = await _context.TUsers
                    .FirstOrDefaultAsync(e => e.UserEmail == tUser.UserEmail && e.UserPass == tUser.UserPass && e.UserStatus == 1);

                if (user == null)
                {
                    TempData["Error"] = "Invalid login credentials";
                    return RedirectToAction("Index");
                }

                HttpContext.Session.SetString("UName", user.UserName);
                HttpContext.Session.SetString("UEmail", user.UserEmail);
                HttpContext.Session.SetInt32("UID", user.UserId);
                HttpContext.Session.SetString("UType", (bool)user.UserType ? "C" : "A");

                if ((bool)user.UserType)
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








        // GET: loginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: loginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: loginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: loginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: loginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: loginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: loginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
