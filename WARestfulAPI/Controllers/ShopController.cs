using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Data;
using WARestfulAPI.Modules.Base;

namespace WARestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Shop> GetAll()
        {
            return _context.Shops.ToList();
        }

        [HttpGet("{id}")]
        public Shop GetById(int id)
        {
            return _context.Shops.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public void Post(Shop item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Shop item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);

            if(shop != null)
            {
                _context.Remove(shop);
                _context.SaveChanges();
            }
        }
    }
}
