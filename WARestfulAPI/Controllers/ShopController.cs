using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task <IEnumerable<Shop>> GetAll()
        {
            var items = _context.Shops.Where(i => i.Id == 1);
            return await items.ToListAsync();
        }

        [HttpGet("{id}")]
        public Shop GetById(int id)
        {
            return _context.Shops.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public async Task Post(Shop item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update(Shop item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var shop = _context.Shops.FirstOrDefault(s => s.Id == id);

            if(shop != null)
            {
                _context.Remove(shop);
                await _context.SaveChangesAsync();
            }
        }
    }
}
