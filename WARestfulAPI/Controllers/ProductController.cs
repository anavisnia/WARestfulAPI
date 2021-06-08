using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Data;
using WARestfulAPI.Modules;
using WARestfulAPI.Modules.Base;

namespace WARestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Product> getAll()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public void Create(Product item)
        {
            if (item == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Product item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var shop = _context.Products.FirstOrDefault(s => s.Id == id);

            if (shop != null)
            {
                _context.Remove(shop);
                _context.SaveChanges();
            }
        }
    }
}
