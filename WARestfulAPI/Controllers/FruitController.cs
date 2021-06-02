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
        private readonly DataService _dataService;

        public FruitController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public List<Fruit> GetAll()
        {
            return _dataService.Fruits;
        }

        [HttpGet("{id}")]
        public Fruit GetById(int id)
        {
            var fruit = _dataService.Fruits.FirstOrDefault(f => f.Id == id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }

            return fruit;
        }

        [HttpPost]
        public void Create(Fruit fruit)
        {
            _dataService.Fruits.Add(fruit);
        }

        //[HttpPut("{id}")]
        //public void Update(int id, Fruit fruit)
        //{
        //    var fruitToUpdate = _dataService.Fruits.FirstOrDefault(f => f.Id == id);

        //    if (fruit == null)
        //    {
        //        throw new KeyNotFoundException();
        //    }

        //    _dataService.Fruits[fruitToUpdate.Id] = fruit;
        //}

        [HttpPut]
        public void Update(Fruit fruit)
        {
            var fruitToUpdate = _dataService.Fruits.FirstOrDefault(f => f.Id == fruit.Id);

            if (fruit == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Fruits[fruit.Id] = fruit;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var fruit = _dataService.Fruits.FirstOrDefault(f => f.Id == id);

            if(fruit == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Fruits.Remove(fruit);
        }
    }
}
