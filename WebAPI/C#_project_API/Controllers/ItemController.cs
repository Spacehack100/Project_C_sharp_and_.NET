using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C__project_API.Models;
using C__project_API.Repositories;
using AutoMapper;
using C__project_API.dto;

namespace C__project_API.Controllers
{
    [ApiController]
    [Route("api/item")]

    public class ItemController : ControllerBase
    {
        private readonly IRepo repo;
        private readonly IMapper map;

        public ItemController(IRepo _repo, IMapper _map)
        {
            repo = _repo;
            map = _map;
        }

        [HttpGet]
        public ActionResult GetAllItems()
        {
            return Ok(map.Map<IEnumerable<ItemReadDto>>(repo.GetAllItems()));
        }

        [HttpGet("{name}", Name="GetItemByName")]
        public ActionResult GetItemByName(string name)
        {
            return Ok(map.Map<ItemReadDto>(repo.GetItemByName(name)));
        }

        [HttpPost]
        public ActionResult AddItem(ItemWriteDto i)
        {
            var item = map.Map<Item>(i);
            repo.AddItem(item);
            repo.SaveChanges();

            return CreatedAtRoute(nameof(GetItemByName), new {name = item.name}, item);
        }

        [HttpPut("{name}")]
        public ActionResult UpdateItem(string name, ItemUpdateDto i)
        {
            var existingItem = repo.GetItemByName(name);

            if(existingItem == null)
            {
                return NotFound();
            }

            map.Map(i, existingItem);
            repo.UpdateItem(existingItem);
            repo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{name}")]
        public ActionResult DeleteItem(string name)
        {
            var existingItem = repo.GetItemByName(name);

            if(existingItem == null)
            {
                return NotFound();
            }

            repo.DeleteItem(existingItem);
            repo.SaveChanges();

            return Ok();
        }
    }
}