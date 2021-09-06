using Foodilizer_Group35.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Graph;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Foodilizer_Group35.Controllers
{
    public class OwnerController : Controller
    {
        private readonly foodilizerContext _context;
        public OwnerController(foodilizerContext context)
        {
            _context = context;
        }
        public IActionResult Owner_home()
        {
            return View();
        }
        public IActionResult Owner_register()
        {
            return View();
        }
        public IActionResult Owner_price()
        {
            return View();
        }
        public IActionResult Owner_redirect()
        {
            return View();
        }
        public IActionResult Registerdummy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterDetails(IFormCollection collection)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    //await Response.WriteAsync(collection["Remail"].ToString());
                    var restdetails = await _context.Restaurants.FirstOrDefaultAsync(e => e.Remail == collection["Remail"].ToString() /*&& e.User_status == 1*/);

                    if (restdetails != null)
                    {
                        //await Response.WriteAsync(collection["Remail"].ToString() + "Already have");

                        TempData["Error"] = "A User with the email already exists. Did you meant to Sign in?";
                        return RedirectToAction("Index");
                    }
                    //await Response.WriteAsync(collection["logo"]);
                    var updateuser = new User();
                    var createrestaurant = new Restaurant();
                    //updateuser.UserStatus = 1;
                    //customer.ShaEnc();
                    string encpass = ShaEnc(collection["Rpassword"].ToString());
                    //await _context.SaveChangesAsync();


                    //updateuser.UserId = collection[""];
                    updateuser.Email = collection["Remail"];
                    updateuser.Password = encpass;
                    updateuser.UserType = "REST";
                    _context.Add(updateuser);

                    createrestaurant.Remail = collection["Remail"];
                    createrestaurant.Rname = collection["Rname"];
                    createrestaurant.OwnerName = collection["OwnerName"];
                    createrestaurant.OwnerContact = collection["OwnerContact"];
                    createrestaurant.OwnerEmail = collection["OwnerEmail"];
                    createrestaurant.Rabout = collection["Rabout"];
                    createrestaurant.RestType = collection["RestType"];
                    createrestaurant.Raddress = collection["Raddress"];
                    createrestaurant.Rdistrict = collection["Rdistrict"];
                    createrestaurant.PriceRange = collection["PriceRange"];
                    createrestaurant.Rusername = collection["Remail"]; //username is same as email
                    createrestaurant.Rpassword = encpass;
                    createrestaurant.Rdistrict = collection["Rdistrict"];
                    //createrestaurant.Rprovince = "Dummy";
                    createrestaurant.OpenHour = collection["OpenHour"];
                    createrestaurant.OpenStatus = 1;
                    createrestaurant.WebsiteLink = collection["WebsiteLink"];
                    createrestaurant.MapLink = collection["MapLink"];
                    createrestaurant.MealType = collection["MealType"];
                    createrestaurant.Cuisine = collection["Cuisine"];
                    createrestaurant.Feature = collection["Feature"];
                    createrestaurant.SpecialDiet = collection["SpecialDiet"]; //this is food options on UI
                    _context.Add(createrestaurant);
                    //_context.Add(customer);
                    await _context.SaveChangesAsync();
                    UploadFile(collection["Remail"]);

                    TempData["Message"] = "User registered.";
                    return RedirectToAction(nameof(Owner_home));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.ToString().Contains("Violation of UNIQUE KEY constraint")) ViewBag.Error = "This email is already used. Please use another email address";
                    else ViewBag.Error = "Unable to register this user. Please try agian";
                    return View(/*customer*/);

                }

            }
            ViewBag.Error = "Unable to register this user. Please try agian";
            return View(/*customer*/);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string ShaEnc(string Rpassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Rpassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Rpassword = builder.ToString();
                return Rpassword;
            }
        }
        public void UploadFile(string email)
        {

            string folderPath = "~/Files/";

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            ////Save the File to the Directory (Folder).
            //FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

            ////Display the success message.
            //lblMessage.Text = Path.GetFileName(FileUpload1.FileName) + " has been uploaded.";
        }
    }
}

