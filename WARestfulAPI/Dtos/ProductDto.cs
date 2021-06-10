using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Dtos.Base;

namespace WARestfulAPI.Dtos
{
    public class ProductDto : DtoObject
    {
        public int Quantity { get; set; }

        public int ShopId { get; set; }
    }
}
