using Newtonsoft.Json;
using Project_C_sharp_and_.NET;
using System.Collections.ObjectModel;

namespace Project_C_sharp_and_NET_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfSorted()
        {
            ObservableCollection<Item> orignalList = new ObservableCollection<Item> 
            {
                new Item { name = "Jens", gsmNumber = "+32473502266", landLineNumber = "+32756985874" },
                new Item { name = "Sven", gsmNumber = "+85473502266", landLineNumber = "+85756985874" },
                new Item { name = "Martine", gsmNumber = "+54473502266", landLineNumber = "+54756985874" }
            };
            ObservableCollection<Item> resultList= new ObservableCollection<Item>()
            {
                 new Item { name = "Jens", gsmNumber = "+32473502266", landLineNumber = "+32756985874" },
                 new Item { name = "Martine", gsmNumber = "+54473502266", landLineNumber = "+54756985874" },
                 new Item { name = "Sven", gsmNumber = "+85473502266", landLineNumber = "+85756985874" }
            };      

            ObservableCollection<Item> sortedList = MainViewModel.sortList(orignalList);
            var sortedStr = JsonConvert.SerializeObject(sortedList);
            var resultStr = JsonConvert.SerializeObject(resultList);

            Assert.Equal(resultStr, sortedStr);
        }
    }
}