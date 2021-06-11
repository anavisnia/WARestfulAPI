using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WARestfulAPI.Entities.Base
{
    public class Shop : Entity
    {
        public List<Product> Products { get; set; }
    }
}