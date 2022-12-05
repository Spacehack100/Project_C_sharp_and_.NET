using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__project_API.Models;

namespace C__project_API.Repositories
{
    public class MockRepo : IRepo
    {
        List<Item> itemList = new List<Item>();

        public MockRepo()
        {
            itemList.Add(new Item(){id=1, name="jens",value1="test1"});
            itemList.Add(new Item(){id=2, name="sven",value1="test2"});
            itemList.Add(new Item(){id=3, name="martine",value1="test3"});
            itemList.Add(new Item(){id=4, name="jeff",value1="test4"});
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);
        }

        public void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return itemList;
        }

        public Item GetItemByName(string name)
        {
            Item item = itemList.FirstOrDefault<Item>(i => i.name == name);
            return item;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}