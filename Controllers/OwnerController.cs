using Foodilizer_Group35.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Foodilizer_Group35.Controllers
{
    public class OwnerController : Controller
    {
      

        // GET: OwnerController
        public ActionResult owner_home()
        {
            return View();
        }
        public ActionResult Index()
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
                return View(dbmodel.Restaurants.ToList());
        }



        // GET: OwnerController/Create
        public ActionResult owner_register()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            // try
            //{
            using (foodilizerContext dbmodel = new foodilizerContext())
            {
                dbmodel.Restaurants.Add(restaurant);
                dbmodel.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
          //  }
          //  catch
            //{
              //  return View();
            //}
        }

        
    }
}
