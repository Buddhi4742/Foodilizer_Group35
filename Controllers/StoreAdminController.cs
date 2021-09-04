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
            return View();
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
            return View();
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
