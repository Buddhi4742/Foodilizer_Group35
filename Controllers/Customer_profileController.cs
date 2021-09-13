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
    public class Customer_profileController : Controller
    {
        // GET: Customer_ProfileController
        private readonly foodilizerContext _context;

        public Customer_profileController(foodilizerContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult customer_profile_orders()
        {
            int id = 1;
            var query = _context.Customers.Where(e => e.CustomerId == id).Include(e => e.RestaurantOrders).ThenInclude(e => e.Rest).ToList();
            ViewBag.customerOrders = query;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            }
        }

        public ActionResult customer_profile_reviews()
        {
            int id = 1;
            var query = _context.Customers.Where(e => e.CustomerId == id).Include(e => e.Reviews).ThenInclude(e => e.Rest).ToList();
            ViewBag.customerReviews = query;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).Include(e => e.Reviews).FirstOrDefault());
            }
        }

        public ActionResult customer_profile_edit()
        {
            int id = 1;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            }
        }


        // GET: Customer_ProfileController/Details/5
        public ActionResult Details()
        {
            int id = 1;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            }
        }

        // GET: Customer_ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_ProfileController/Create
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

        // GET: Customer_ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer_ProfileController/Edit/5
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

        // GET: Customer_ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer_ProfileController/Delete/5
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
