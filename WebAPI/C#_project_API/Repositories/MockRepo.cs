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
            itemList.Add(new Item(){id=1, name="jens",gsmNumber="+32586953214",landLineNumber="+322548165210"});
            itemList.Add(new Item(){id=2, name="sven",gsmNumber="+65586953214",landLineNumber="+652548165210"});
            itemList.Add(new Item(){id=3, name="martine",gsmNumber="+88586953214",landLineNumber="+882548165210"});
            itemList.Add(new Item(){id=4, name="jeff",gsmNumber="+01586953214",landLineNumber=""});
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