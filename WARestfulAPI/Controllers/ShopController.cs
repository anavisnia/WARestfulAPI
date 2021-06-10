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
    public class ShopController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly GenericRepository<Shop> _repository;

        public ShopController(IMapper mapper, GenericRepository<Shop> repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task <IEnumerable<Shop>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public Shop GetById(int id)
        {
            return _repository.FindById(id);
        }

        [HttpPost]
        public async Task Upsert(ShopDto dto)
        {
            var entity = _mapper.Map<Shop>(dto);

            await _repository.Upsert(entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
