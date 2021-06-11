using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARestfulAPI.Modules.Base
{
    public class Product : Entity
    {
        public int Quantity { get; set; }

        public Shop Shop { get; set; }

        public int ShopId { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
