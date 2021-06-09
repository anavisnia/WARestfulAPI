using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARestfulAPI.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int ShopId { get; set; }
    }
}
