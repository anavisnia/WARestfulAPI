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
        private readonly DataContext _context;

        public VegetableController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Vegetable> getAll()
        {
            return _context.Vegetables.ToList();
        }

        [HttpGet("{id}")]
        public Vegetable GetById(int id)
        {
            var vegetable = _context.Vegetables.FirstOrDefault(v => v.Id == id);

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

            _context.Vegetables.Add(vegetable);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Vegetable vegetable)
        {
            var toBeUpdatedVegetable = _context.Vegetables.FirstOrDefault(v => v.Id == vegetable.Id);

            if(vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            //_context.Vegetables[vegetable.Id] = vegetable;
            _context.Update(vegetable);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var vegitable = _context.Vegetables.FirstOrDefault(v => v.Id == id);

            _context.Vegetables.Remove(vegitable);
            _context.SaveChanges();
        }
    }
}
