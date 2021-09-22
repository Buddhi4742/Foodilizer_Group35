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
            if (HttpContext.Session.GetInt32("user_email") == null)
            {
                TempData["Name"] = null;
                TempData["Id"] = null;
            }
      
            if (HttpContext.Session.GetInt32("user_email") != null)
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


            var resfood = _context.Foods.ToList();
            foreach (var item in resfood)
            {

                var prefscore = resfood.OrderByDescending(c => c.PrefScore).ToList();
                ViewBag.recommendation = prefscore;
            }
            foreach (var item in resfood)
            {
                var ran = new Random();
                var rf = resfood.OrderBy(x => ran.Next()).ToList() ;
                ViewBag.featured = rf;
            }



            var query3 = _context.Restaurants.Include(e => e.Reviews).ToList();
            int c = query3.Count();
            int count = 0;
            double[,] array = new double[c, 2];
            int i = 0;
            int j = 0;



            foreach (var item2 in query3)
            {
                if (item2.RestId != 0)
                {
                    int rid = item2.RestId;

                    var rate = _context.Reviews.Where(e => e.RestId == rid).ToList();
                    double avg = System.Convert.ToDouble((from x in rate select x.Rating).Average());
                    array[i, 0] = item2.RestId;
                    array[i, 1] = avg;
                    i++;
                    count++;
                }

            }

            for (i = 0; i < count; i++)
            {
                for (j = 0; j < count - 1 - i; j++)
                {
                    if (array[j, 1] < array[j + 1, 1]) // column 1 entry comparison
                    {
                        double temp1 = array[j, 0];              // swap both column 0 and column 1
                        double temp2 = array[j, 1];

                        array[j, 0] = array[j + 1, 0];
                        array[j, 1] = array[j + 1, 1];

                        array[j + 1, 0] = temp1;
                        array[j + 1, 1] = temp2;
                    }
                }
            }
            var query4 = _context.Restaurants.Where(e => e.RestId == array[0, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating1 = query4;
            var query5 = _context.Restaurants.Where(e => e.RestId == array[1, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating2 = query5;
            var query6 = _context.Restaurants.Where(e => e.RestId == array[2, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating3 = query6;
            var query7 = _context.Restaurants.Where(e => e.RestId == array[3, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating4 = query7;
            var query8 = _context.Restaurants.Where(e => e.RestId == array[4, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating5 = query8;



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
