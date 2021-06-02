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

        public List<Vagetable> Vagetables { get; set; }

        public DataService()
        {
            Fruits = new List<Fruit>();
            Tablewares = new List<Tableware>();
            Vagetables = new List<Vagetable>();
        }
    }
}
