using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
//using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodilizer_Group35.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Graph;

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
            HttpContext.Session.SetString("user_email", "");
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
                    //var customerDetails = _context.Customers.Where(x => x.Cemail == userDetails.Email).FirstOrDefault();
                    //HttpContext.Session.SetString("user_name", userDetails.);
                    HttpContext.Session.SetString("user_email", userDetails.Email);
                    HttpContext.Session.SetInt32("user_id", userDetails.UserId);
                    HttpContext.Session.SetString("user_type", userDetails.UserType);
                    //HttpContext.Session.Clear();


                    if (userDetails.UserType == "CUST")
                    {
                        //var id = HttpContext.Session.GetInt32("user_id");
                        //await Response.WriteAsync("The login is cust and id" + id.ToString());
                        if (HttpContext.Session.GetInt32("user_email") != null)
                        {
                            var name = await _context.Customers.FirstOrDefaultAsync(x => x.Cemail == HttpContext.Session.GetString("user_email"));
                            TempData["Name"] = name.Name;
                            TempData["Id"] = HttpContext.Session.GetInt32("user_id");
                        }
                        return RedirectToAction("Index", "Home");
                        //return Print;
                    }
                    else if (userDetails.UserType == "ADMIN")
                    {
                        TempData["Id"] = HttpContext.Session.GetInt32("user_id");
                        return RedirectToAction("Resturants", "Foodilizer_admin");
                    }
                    else if (userDetails.UserType == "REST")
                    {
                        var name = await _context.Restaurants.FirstOrDefaultAsync(x => x.Remail == HttpContext.Session.GetString("user_email"));
                        TempData["Name"] = name.OwnerName;
                        TempData["Rest_Id"] = name.RestId;
                        string resttype = name.RestType.ToString();
                        HttpContext.Session.SetString("rest_type", resttype);
                        TempData["RestType"]=resttype;

                        return RedirectToAction("Menu", "StoreAdmin");
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
                try
                {
                    var custDetails = await _context.Customers.FirstOrDefaultAsync(e => e.Cemail == customer.Cemail /*&& e.User_status == 1*/);

                    if (custDetails != null)
                    {
                        TempData["Error"] = "A User with the email already exists. Did you meant to Sign in?";
                        return RedirectToAction("Index");
                    }
                    var updateuser = new User();
                    //updateuser.UserStatus = 1;
                    customer.ShaEnc();

                    //await _context.SaveChangesAsync();

                   
                //updateuser.UserId = customer.CustomerId;
                updateuser.Email = customer.Cemail;
                updateuser.Password = customer.Password;
                updateuser.UserType = "CUST";
                _context.Add(updateuser);
                _context.Add(customer);

                await _context.SaveChangesAsync();

                TempData["Message"] = "User registered.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.ToString().Contains("Violation of UNIQUE KEY constraint")) ViewBag.Error = "This email is already used. Please use another email address";
                    else ViewBag.Error = "Unable to register this user. Please try agian";
                    return View(customer);

                }

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

