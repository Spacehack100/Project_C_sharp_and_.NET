using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__project_API.Contexts;
using C__project_API.Models;

namespace C__project_API.Repositories
{
    public class MysqlRepo : IRepo
    {
        private readonly ItemContext context;

        public MysqlRepo(ItemContext _context)
        {
            context = _context;
        }

        public void AddItem(Item item)
        {
            context.items.Add(item);
        }

        public void DeleteItem(Item item)
        {
            context.items.Remove(item);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return context.items;
        }

        public Item GetItemByName(string name)
        {
            return context.items.FirstOrDefault(item => item.name == name);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            
        }
    }
}