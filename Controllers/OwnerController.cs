using Foodilizer_Group35.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc.Filters;

namespace Foodilizer_Group35.Controllers
{
    public class OwnerController : Controller
    {
        private readonly foodilizerContext _context;
        public OwnerController(foodilizerContext context)
        {
            _context = context;
        }

        // GET: OwnerController
        public IActionResult owner_home()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: OwnerController/Create
        public IActionResult owner_register()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Owner_register([Bind("Rname,Owner_name,Owner_contact,Owner_email,Rabout,Rest_type,Remail,Raddress,Rdistrict,Price_range,Rusername,Rpassword,Rprovince,Open_hour,Open_status,Website_link,Map_link,Meal_type,Cuisine,Feature,Special_diet")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                


                var updateuser = new User();
                updateuser.UserId = restaurant.RestId;
                updateuser.Email = restaurant.Remail;
                updateuser.Password =restaurant.Rpassword;
                updateuser.UserType = "REST";
                _context.Add(updateuser);
                _context.Add(restaurant);

                await _context.SaveChangesAsync();

                TempData["Message"] = "User registered.";
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Error = "Unable to register this user. Please try agian";
            return View(restaurant);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
