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
    public class VegetableController : ControllerBase
    {
        private DataService _dataService;

        public VegetableController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public List<Vegetable> getAll()
        {
            return _dataService.Vegetables;
        }

        [HttpGet("{id}")]
        public Vegetable GetBYId(int id)
        {
            var vegetable = _dataService.Vegetables.FirstOrDefault(v => v.Id == id);

            if(vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            return vegetable;
        }

        [HttpPost]
        public void Create(Vegetable vegetable)
        {
            if(vegetable == null)
            {
                throw new KeyNotFoundException();
            }
            _dataService.Vegetables.Add(vegetable);
        }

        [HttpPut]
        public void Update(Vegetable vegetable)
        {
            var toBeUpdatedVegetable = _dataService.Vegetables.FirstOrDefault(v => v.Id == vegetable.Id);

            if(vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Vegetables[vegetable.Id] = vegetable;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var vegitable = _dataService.Vegetables.FirstOrDefault(v => v.Id == id);

            _dataService.Vegetables.Remove(vegitable);
        }
    }
}
