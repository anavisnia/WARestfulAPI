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
        private readonly DataService _dataService;

        public TablewareController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public List<Tableware> GetAll()
        {
            return _dataService.Tablewares;
        }

        [HttpGet("{id}")]
        public Tableware GetById(int id)
        {
            var tableware = _dataService.Tablewares.FirstOrDefault(t => t.Id == id);

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

            _dataService.Tablewares.Add(tableware);
        }

        [HttpPut]
        public void Update(Tableware tableware)
        {
            var tablewareToUpdate = _dataService.Tablewares.FirstOrDefault(t => t.Id == tableware.Id);

            if(tableware == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Tablewares[tableware.Id] = tableware;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tableware = _dataService.Tablewares.FirstOrDefault(t => t.Id == id);

            if(tableware == null)
            {
                throw new KeyNotFoundException();
            }

            _dataService.Tablewares.Remove(tableware);
        }
    }
}
