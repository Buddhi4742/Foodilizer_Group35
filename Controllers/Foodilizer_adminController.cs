using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
//using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodilizer_Group35.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodilizer_Group35.Controllers
{
    public class Foodilizer_adminController : Controller
    {
        private readonly foodilizerContext _context;

        public Foodilizer_adminController(foodilizerContext context)
        {
            _context = context;
        }
        // GET: Foodilizer_adminController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Resturants()
        {
            return View(_context.Restaurants.ToList());
        }

        public ActionResult ResturantsDetails(int id)
        {

            return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());

        }
        public IActionResult ResturantsDelete(int id)
        {
            //Response.WriteAsync(id.ToString());
            return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResturantsDelete(int id, IFormCollection collection)
        {
            try
            {
                //Response.WriteAsync(id.ToString());
                Restaurant rest = _context.Restaurants.Where(x => x.RestId == id).FirstOrDefault();
                _context.Restaurants.Remove(rest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Resturants));
            }
            catch
            {
                return View();
            }
        }





        public ActionResult Users()
        {
            return View(_context.Customers.ToList());
        }
        public ActionResult UsersDetails(int id)
        {

            return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());

        }
        public IActionResult UsersBan(int id)
        {
            //Response.WriteAsync(id.ToString());
            return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UsersDelete(int id, IFormCollection collection)
        {
            try
            {
                //Response.WriteAsync(id.ToString());
                Customer Cust = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                _context.Customers.Remove(Cust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Users));
            }
            catch
            {
                return View();
            }
        }

    }
}
