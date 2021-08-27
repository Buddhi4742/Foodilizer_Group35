using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Foodilizer_Group35.Models
{
    public class RestRegis
    {
      
        public int RestId { get; set; }
        
        public string Rname { get; set; }
       
        public string OwnerName { get; set; }
     
        public string OwnerContact { get; set; }
       
        public string OwnerEmail { get; set; }
      
        public string Rabout { get; set; }
        
        public string RestType { get; set; }
      
        public string Remail { get; set; }
        
        public string Raddress { get; set; }
        
        public string Rdistrict { get; set; }
       
        public string PriceRange { get; set; }
    
        public string Rusername { get; set; }
    
        public string Rpassword { get; set; }
  
   
        public string Rprovince { get; set; }
     
        public string OpenHour { get; set; }
       
        public sbyte? OpenStatus { get; set; }
     
        public string WebsiteLink { get; set; }
 
        public string MapLink { get; set; }
  
        public string MealType { get; set; }

        public string Cuisine { get; set; }
 
        public string Feature { get; set; }
   
        public string SpecialDiet { get; set; }

        public string ContactNumber { get; set; }

        public string MainImagePath { get; set; }

        public void ShaEnc()
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
            }
        }






    }
}
