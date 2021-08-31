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
    public class store_frontController : Controller
    {
        private readonly foodilizerContext _context;

        public store_frontController(foodilizerContext context)
        {
            _context = context;
        }

        public IActionResult bronze_home()
        {
            int id = 1;
            var det = (from m in _context.Menus
                       join f in _context.Foods on m.MenuId equals f.MenuId
                       where (m.MenuId==id)
                      select new
                      {
                          fname = f.FoodName
                          
                      }).ToList();
            Console.WriteLine(det);
            
            ViewBag.fooddet = det;

            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
            }


        }

        public IActionResult silver_home()
        {
            int id = 3;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
            }
        }
        public IActionResult gold_home()
        {
            int id = 5;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
            }
        }
        public IActionResult silver_cart()
        {
            return View();
        }
        public IActionResult gold_cart()
        {
            return View();
        }
        public IActionResult silver_checkout()
        {
            return View();
        }
        public IActionResult gold_checkout()
        {
            return View();
        }

    }
}
