using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Data;
using WARestfulAPI.Modules;

namespace WARestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly DataContext _context;

        public FruitController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Fruit> GetAll()
        {
            return _context.Fruits.ToList();
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

        [HttpPost]
        public void Create(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            _context.SaveChanges();
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
        public void Update(Fruit fruit)
        {
            var fruitToUpdate = _context.Fruits.FirstOrDefault(f => f.Id == fruit.Id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }

            //_context.Fruits[fruit.Id] = fruit;
            //_context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);

            if(fruit == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Fruits.Remove(fruit);
            _context.SaveChanges();
        }
    }
}
