using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Modules;

namespace WARestfulAPI.Data
{
    public class DataService
    {
        public List<Fruit> Fruits { get; set; }

        public List<Tableware> Tablewares { get; set; }

        public List<Vegetable> Vegetables { get; set; }

        public DataService()
        {
            Fruits = new List<Fruit>();
            Tablewares = new List<Tableware>();
            Vegetables = new List<Vegetable>();
        }
    }
}
