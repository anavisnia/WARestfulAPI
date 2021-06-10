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
    public class VegetableController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VegetableController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<List<ProductDto>> getAll()
        {
            var entity = await _context.Tablewares.Include(s => s.shop).ToListAsync();

            return _mapper.Map<List<ProductDto>>(entity);
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
        public async Task Create(Vegetable vegetable)
        {
            if(vegetable == null)
            {
                throw new KeyNotFoundException();
            }
            var entity = _mapper.Map<Vegetable>(vegetable);

            _context.Vegetables.Add(entity);

            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update(Vegetable vegetable)
        {
            var toBeUpdatedVegetable = _context.Vegetables.FirstOrDefault(v => v.Id == vegetable.Id);

            if(vegetable == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Update(vegetable);

            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var vegitable = _context.Vegetables.FirstOrDefault(v => v.Id == id);

            _context.Vegetables.Remove(vegitable);
            await _context.SaveChangesAsync();
        }
    }
}
