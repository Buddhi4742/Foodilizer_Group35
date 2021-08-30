using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Collections.Generic;
using Foodilizer_Group35.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodilizer_Group35.Controllers
{
    public class RestDemoController : Controller
    {
        private readonly foodilizerContext _context;
        public RestDemoController(foodilizerContext context)
        {
            _context = context;
        }
        // GET: RestDemoController
        public ActionResult Index()
        {
            return View(_context.Restaurants.ToList());
        }

        // GET: RestDemoController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
        }

        // GET: RestDemoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestDemoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: RestDemoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestDemoController/Edit/5
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

        // GET: RestDemoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestDemoController/Delete/5
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
