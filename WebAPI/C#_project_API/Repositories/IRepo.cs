using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__project_API.Models;

namespace C__project_API.Repositories
{
    public interface IRepo
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemByName(string name);

        void AddItem(Item item);

        void UpdateItem(Item item);

        void DeleteItem(Item item);

        void SaveChanges();
    }
}