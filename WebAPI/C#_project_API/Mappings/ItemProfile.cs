using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using C__project_API.dto;
using C__project_API.Models;

namespace C__project_API.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemWriteDto, Item>();
            CreateMap<ItemUpdateDto, Item>();
        }
    }
}