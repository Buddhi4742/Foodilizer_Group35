using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodilizer_Group35.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;


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
        public async Task<IActionResult> LoginMember([Bind("Email,Password")] User user)
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
                else
                {
                    var customerDetails = _context.Customers.Where(x => x.Cemail == userDetails.Email).FirstOrDefault();
                    HttpContext.Session.SetString("user_name", customerDetails.Name);
                    HttpContext.Session.SetString("user_email", customerDetails.Cemail);
                    HttpContext.Session.SetInt32("user_id", userDetails.UserId);
                    HttpContext.Session.SetString("user_type", userDetails.UserType);

                    if (userDetails.UserType == "CUST")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (userDetails.UserType == "ADMIN")
                    {
                        //buddhi
                        return RedirectToAction("Index", "Home");
                    }
                    else if (userDetails.UserType == "REST")
                    {
                        //viganis
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //buddhi
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "Error occured during login process. Please try again.";
                return RedirectToAction("Index");
            }
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Password,Cemail,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                    //user.UserStatus = 1;
                    customer.ShaEnc();
                    
                //await _context.SaveChangesAsync();

                var updateuser = new User();
                updateuser.UserId = customer.CustomerId;
                updateuser.Email = customer.Cemail;
                updateuser.Password = customer.Password;
                updateuser.UserType = "CUST";
                _context.Add(updateuser);
                _context.Add(customer);

                await _context.SaveChangesAsync();

                TempData["Message"] = "User registered.";
                    return RedirectToAction(nameof(Index));
                //}
                //catch (Exception ex)
                //{
                //    if (ex.InnerException.ToString().Contains("Violation of UNIQUE KEY constraint")) ViewBag.Error = "This email is already used. Please use another email address";
                //    else ViewBag.Error = "Unable to register this user. Please try agian";
                //    return View(customer);

                //}

            }
            ViewBag.Error = "Unable to register this user. Please try agian";
            return View(customer);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}

