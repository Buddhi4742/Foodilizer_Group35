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
        public IActionResult RestRegister()
        {

            return RedirectToAction("Owner_home", "Owner");
        }

        public IActionResult Index()
        {
           
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
