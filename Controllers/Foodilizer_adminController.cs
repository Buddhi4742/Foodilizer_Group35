using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodilizer_Group35.Controllers
{
    public class Foodilizer_adminController : Controller
    {
        // GET: Foodilizer_adminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Foodilizer_adminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Foodilizer_adminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Foodilizer_adminController/Create
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

        // GET: Foodilizer_adminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Foodilizer_adminController/Edit/5
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

        // GET: Foodilizer_adminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Foodilizer_adminController/Delete/5
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
