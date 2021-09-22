using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodilizer_Group35.Models
{
    public class cart
    {
        public int Qty { get; set; } = 1;
        public int id { get; set; }
        public Food Food { get; set; } = null;
    }
}
