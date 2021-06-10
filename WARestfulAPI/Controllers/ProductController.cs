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
using WARestfulAPI.Repositories;

namespace WARestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<Product> _repository;

        public ProductController(IMapper mapper, GenericRepository<Product> repository)
        {
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAll()
        {
            // if shopId was not indicated it won't show up in the list
            //var entities = await _context.Products.Include(p => p.shop).ToListAsync();
            //var entities = await _context.Products.ToListAsync();

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

            var entities = await _repository.GetAll();

            return _mapper.Map<List<ProductDto>>(entities);
        }

        [HttpGet("{id}")]
        public ProductDto GetById(int id)
        {
            var entity = _repository.FindById(id);

            return _mapper.Map<ProductDto>(entity);
        }

        [HttpPost]
        public async Task Upsert(ProductDto item)
        {
            var entity = _mapper.Map<Product>(item);

            await _repository.Upsert(entity);
        }

        //[HttpPut]
        //public async Task Update(Product item)
        //{
        //    _context.Update(item);
        //    await _context.SaveChangesAsync();
        //}

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
