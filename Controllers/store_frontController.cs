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
    public class Store_frontController : Controller
    {
        private readonly foodilizerContext _context;

        public Store_frontController(foodilizerContext context)
        {
            _context = context;
        }

        public IActionResult bronze_home()
        {
            int id = 2;


            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            ViewBag.fooddet = query;

            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());
            }


        }

        public IActionResult silver_home()
        {
            int id = 3;

            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            ViewBag.fooddet = query;
            ViewBag.count = 0;

            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());
            }
        }
        public IActionResult gold_home()
        {
            int id = 5;

            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            ViewBag.fooddet = query;
            ViewBag.count = 0;

            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());
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
