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

namespace WARestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FruitController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet]
        //public List<Fruit> GetAll()
        //{
        //    return _context.Fruits.ToList();
        //}

        [HttpGet]
        public async Task<List<ProductDto>> GetAll()
        {
            var entities = await _context.Fruits.Include(p => p.shop).ToListAsync();

            return _mapper.Map<List<ProductDto>>(entities);
        }

        [HttpGet("{id}")]
        public Fruit GetById(int id)
        {
            var fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }

            return fruit;
        }

        //[HttpPost]
        //public void Create(Fruit fruit)
        //{
        //    _context.Fruits.Add(fruit);
        //    _context.SaveChanges();
        //}

        [HttpPost]
        public async Task Create(ProductDto fruit)
        {
            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }

            var entity = _mapper.Map<Fruit>(fruit);

            _context.Fruits.Add(entity);

            await _context.SaveChangesAsync();
        }

        //[HttpPut("{id}")]
        //public void Update(int id, Fruit fruit)
        //{
        //    var fruitToUpdate = _context.Fruits.FirstOrDefault(f => f.Id == id);

        //    if (fruit == null)
        //    {
        //        throw new KeyNotFoundException();
        //    }

        //    _context.Fruits[fruitToUpdate.Id] = fruit;
        //}

        [HttpPut]
        public async Task Update(Fruit fruit)
        {
            var fruitToUpdate = _context.Fruits.FirstOrDefault(f => f.Id == fruit.Id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }
            
            _context.Update(fruit);
            await _context.SaveChangesAsync();

        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);

            if(fruit == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Fruits.Remove(fruit);
            await _context.SaveChangesAsync();
        }
    }
}
