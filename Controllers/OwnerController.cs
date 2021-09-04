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
        public async Task<IActionResult>RegisterDetails(IFormCollection collection)
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

                    /*await Response.WriteAsync(collection["Remail"].ToString() + "can register");*/
                    var updateuser = new User();
                    //updateuser.UserStatus = 1;
                    //customer.ShaEnc();
                    string encpass = ShaEnc(collection["Rpassword"].ToString());
                     //await _context.SaveChangesAsync();


                     //updateuser.UserId = customer.CustomerId;
                     //updateuser.Email = customer.Cemail;
                     //updateuser.Password = customer.Password;
                     //updateuser.UserType = "CUST";
                     //_context.Add(updateuser);
                     //_context.Add(customer);

                     await _context.SaveChangesAsync();

                    TempData["Message"] = "User registered.";
                    return RedirectToAction(nameof(Index));
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
    }
}
