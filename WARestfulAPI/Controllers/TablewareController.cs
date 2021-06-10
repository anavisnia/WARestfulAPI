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
    public class TablewareController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TablewareController(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAll()
        {
            var entity = await _context.Tablewares.Include(p => p.shop).ToListAsync();

            return _mapper.Map<List<ProductDto>>(entity);
        }

        [HttpGet("{id}")]
        public Tableware GetById(int id)
        {
            var tableware = _context.Tablewares.FirstOrDefault(t => t.Id == id);

            if(tableware == null)
            {
                throw new KeyNotFoundException();
            }

            return tableware;
        }

        [HttpPost]
        public async Task Create(ProductDto tableware)
        {
            if (tableware == null)
            {
                throw new KeyNotFoundException();
            }

            var entity = _mapper.Map<Tableware>(tableware);

            _context.Tablewares.Add(entity);

            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update(Tableware tableware)
        {
            var tablewareToUpdate = _context.Tablewares.FirstOrDefault(t => t.Id == tableware.Id);

            if(tableware == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Update(tableware);

            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var tableware = _context.Tablewares.FirstOrDefault(t => t.Id == id);

            if(tableware == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Tablewares.Remove(tableware);
            await _context.SaveChangesAsync();
        }
    }
}
