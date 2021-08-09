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
    public class itemtable : Controller
    {
        // GET: itemtable
        public ActionResult Index()
        {
            using (foodilizerContext dbmodel= new foodilizerContext())
            return View(dbmodel.Items.ToList());
        }

        // GET: itemtable/Details/5
        public ActionResult Details(int id)
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
            {
                return View(dbmodel.Items.Where(x=> x.ItemId==id).FirstOrDefault());
               
            }
        }

        // GET: itemtable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: itemtable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            try
            {
                using (foodilizerContext dbmodel = new foodilizerContext())
                {
                    dbmodel.Items.Add(item);
                    dbmodel.SaveChanges();
                }
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: itemtable/Edit/5
        public ActionResult Edit(int id)
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
            {
                return View(dbmodel.Items.Where(x => x.ItemId == id).FirstOrDefault());
            }
    
        }

        // POST: itemtable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                using (foodilizerContext dbmodel = new foodilizerContext())
                {
                    dbmodel.Entry(item).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: itemtable/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: itemtable/Delete/5
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
