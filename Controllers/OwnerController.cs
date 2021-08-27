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
       

        // GET: OwnerController
        public IActionResult Owner_home()
        {
            return View();
        }
        public IActionResult Owner_price()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
        private readonly foodilizerContext _context;


        public OwnerController(foodilizerContext context)
        {
            _context = context;
        }
        // GET: OwnerController/Create
        public IActionResult Owner_register()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Owner_register([Bind("Rname,Owner_name,Owner_contact,Owner_email,Rabout,Rest_type,Remail,Raddress,Rdistrict,Price_range,Rusername,Rpassword,Rprovince,Open_hour,Open_status,Website_link,Map_link,Meal_type,Cuisine,Feature,Special_diet,contact_number,main_image_path")] RestRegis restRegis)
        {
            if (ModelState.IsValid)
            {
                try {
                  var  updaterest  = new Restaurant();
                    var restDetails = await _context.Restaurants.FirstOrDefaultAsync(e => e.Remail == restRegis.Remail);

                    if (restDetails != null)
                    {
                        TempData["Error"] = "A User with the email already exists. Did you meant to Sign in?";
                        return RedirectToAction("Owner_register");
                    }
                     var updateuser = new User();
                    var updatecontact = new RestaurantContact();
                    var updateimage = new RestaurantImage();
                    restRegis.ShaEnc();
                    
                updateuser.UserId = restRegis.RestId;
                updateuser.Email = restRegis.Remail;
                updateuser.Password =restRegis.Rpassword;
               updateuser.UserType = "REST";
                  
               _context.Add(updateuser);
                    updaterest.Cuisine = restRegis.Cuisine;
                    updaterest.Feature = restRegis.Feature;
                    updaterest.MapLink = restRegis.MapLink;
                    updaterest.MealType = restRegis.MealType;
                    updaterest.OpenHour = restRegis.OpenHour;
                    updaterest.OwnerContact = restRegis.OwnerContact;
                    updaterest.OwnerEmail = restRegis.OwnerEmail;
                    updaterest.OwnerName = restRegis.OwnerName;
                    updaterest.PriceRange = restRegis.PriceRange;
                    updaterest.Rabout = restRegis.Rabout;
                    updaterest.SpecialDiet = restRegis.SpecialDiet;
                    updaterest.Raddress = restRegis.Raddress;
                    updaterest.Rdistrict = restRegis.Rdistrict;
                    updaterest.Remail = restRegis.Remail;
                    updaterest.RestType = restRegis.RestType;
                    updaterest.Rname = restRegis.Rname;
                    updaterest.Rpassword = restRegis.Rpassword;
                    updaterest.Rprovince = restRegis.Rprovince;
                    updaterest.Rusername = restRegis.Remail;
                    updaterest.WebsiteLink = restRegis.WebsiteLink;

                    _context.Add(updaterest);
                    updatecontact.RestId = restRegis.RestId;
                    updatecontact.ContactNumber = restRegis.ContactNumber;
                    _context.Add(updatecontact);

                    updateimage.MainImagePath = restRegis.MainImagePath;
                    updateimage.RestId = restRegis.RestId;
                    _context.Add(updateimage);


                    await _context.SaveChangesAsync();

                TempData["Message"] = "User registered";
                return RedirectToAction(nameof(Owner_register));

                 }
                catch (Exception ex)
                {
                    if (ex.InnerException.ToString().Contains("Violation of UNIQUE KEY constraint")) ViewBag.Error = "This email is already used. Please use another email address";
                    else ViewBag.Error = "Unable to register this user. Please try agian";
                    return View(restRegis);

                }

            }
            ViewBag.Error = "Unable to register this user. Please try agian";
            return View(restRegis);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
