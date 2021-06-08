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
    public class TablewareController : ControllerBase
    {
        private readonly DataContext _context;

        public TablewareController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public List<Tableware> GetAll()
        {
            return _context.Tablewares.ToList();
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
        public void Create(Tableware tableware)
        {
            if (tableware == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Tablewares.Add(tableware);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Tableware tableware)
        {
            var tablewareToUpdate = _context.Tablewares.FirstOrDefault(t => t.Id == tableware.Id);

            if(tableware == null)
            {
                throw new KeyNotFoundException();
            }

            //_context.Tablewares[tableware.Id] = tableware;
            //_context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tableware = _context.Tablewares.FirstOrDefault(t => t.Id == id);

            if(tableware == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Tablewares.Remove(tableware);
            _context.SaveChanges();
        }
    }
}
