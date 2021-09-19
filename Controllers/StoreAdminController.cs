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
    public class StoreAdminController : Controller
    {

        private readonly foodilizerContext _context;

        public StoreAdminController(foodilizerContext context)
        {
            _context = context;
        }
        // GET: Store_adminController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            int id = 2;
            //var q = ;
            return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
        }
        public ActionResult Menu()
        {
            int id = 2;
            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            ViewBag.fooddet = query;
            return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());

        }
        public ActionResult Inventory()
        {
            int id = 2;
            var q = _context.Items.Where(x => x.RestId == id).ToList();
            return View(q);

        }
        public ActionResult InventoryDetails(int id)
        {
            
            return View(_context.Items.Where(x => x.ItemId == id).FirstOrDefault());
            
        }

        public ActionResult InventoryCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryCreate(Item item)
        {

            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Inventory));
        }
        public ActionResult InventoryEdit(int id)
        {
            
            return View(_context.Items.Where(x => x.ItemId == id).FirstOrDefault());
            
    
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryEdit(int id, Item item)
        {
            try
            {

                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
                

                return RedirectToAction(nameof(Inventory));
            }
            catch
            {
                return View();
            }
        }
        // GET: itemtable/Delete/5
        public ActionResult InventoryDelete(int id)
        {
            //Response.WriteAsync(id.ToString());
            return View(_context.Items.Where(x => x.ItemId == id).FirstOrDefault());
        }

        // POST: itemtable/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryDelete(int id, IFormCollection collection)
        {
            try
            {
                //Response.WriteAsync(id.ToString());
                Item item = _context.Items.Where(x => x.ItemId == id).FirstOrDefault();
                _context.Items.Remove(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Inventory));
            }
            catch
            {
                return View();
            }
        }




        public ActionResult Recomendations()
        {
            return View();
        }
        public ActionResult Banner()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult OtherUsers()
        {
            return View();
        }
        public ActionResult Reports()
        {
            return View();
        }
        public ActionResult Inspect()
        {
            return View();
        }

    }
}
