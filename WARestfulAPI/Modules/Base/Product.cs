using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARestfulAPI.Modules.Base
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public Shop shop { get; set; }
        public int ShopId { get; set; }

        public bool Deleted { get; set; } = false;
    }
}
