using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Data;
using WARestfulAPI.Dtos;
using WARestfulAPI.Modules;
using WARestfulAPI.Modules.Base;

namespace WARestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAll()
        {
            var entities = await _context.Products.Include(p => p.shop).ToListAsync();

            //var dtos = new List<ProductDto>();

            //foreach (var entity in entities)
            //{
            //    dtos.Add(new ProductDto()
            //    {
            //        Name = entity.Name,
            //        Quantity = entity.Quantity,
            //        ShopId = entity.ShopId
            //    });
            //}

            //return dtos;

            return _mapper.Map<List<ProductDto>>(entities);
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public async Task Create(ProductDto item)
        {
            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            var entity = _mapper.Map<Product>(item);

            _context.Products.Add(entity);

            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update(Product item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var shop = _context.Products.FirstOrDefault(s => s.Id == id);

            if (shop != null)
            {
                _context.Remove(shop);
                await _context.SaveChangesAsync();
            }
        }
    }
}
