using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WARestfulAPI.Dtos;
using WARestfulAPI.Modules;
using WARestfulAPI.Modules.Base;

namespace WARestfulAPI.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductDto, Fruit>().ReverseMap();
            CreateMap<ProductDto, Vegetable>().ReverseMap();
            CreateMap<ProductDto, Tableware>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
        }
    }
}
