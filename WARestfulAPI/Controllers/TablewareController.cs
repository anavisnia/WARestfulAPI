using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Controllers.Base;
using WARestfulAPI.Data;
using WARestfulAPI.Dtos;
using WARestfulAPI.Modules;
using WARestfulAPI.Repositories;

namespace WARestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TablewareController : GenericControllerBase<ProductDto, Tableware>
    {

        public TablewareController(IMapper mapper, GenericRepository<Tableware> repository) : base(mapper, repository)
        {

        }
    }
}
