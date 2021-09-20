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

    public class HomeController : Controller
    {
        private readonly foodilizerContext _context;
        public HomeController(foodilizerContext context)
        {
            _context = context;
        }
        public IActionResult RestRegister()
        {

            return RedirectToAction("Owner_home", "Owner");
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("user_email") != null)
            {
                var name = _context.Customers.FirstOrDefault(x => x.Cemail == HttpContext.Session.GetString("user_email"));
                TempData["Name"] = name.Name;
                TempData["Id"] = HttpContext.Session.GetInt32("user_id");
            }
            var location = _context.Restaurants.Select(x => x.Rdistrict).Distinct().ToList();
            ViewBag.restlocation = location;

            //var bestRes = _context.Restaurants.SelectOrderByDescending.toList();
            //var results = _context.Restaurants.Select(x => x.RestId).OrderBy(x => x.rateing);


            //var bestFood = _context.Foods.Select(x => x.FoodId).OrderBy(x => x.PrefScore);

            return View();
        }
        public IActionResult Login()
        {

            return RedirectToAction("Index", "Login");
        }
        public IActionResult Signup()
        {
          
                return View();
        }

        [HttpPost]
        public IActionResult Signup(Customer customer)
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
            if (dbmodel.Customers.Any(x => x.Cemail == customer.Cemail))
            {
                    ViewBag.Notifcation = "This email already has an account";
                    return View();
            }
            else
            {
                    dbmodel.Customers.Add(customer);
                    dbmodel.SaveChanges();

                    //Session["CustsomerIdSS"] = customer.CustomerId.ToString();
                    //Session["CustsomerEmailSS"] = customer.Email.ToString();
                    return RedirectToAction("index", "Home");

            }
        }
    }
}
