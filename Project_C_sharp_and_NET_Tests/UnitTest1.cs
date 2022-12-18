using Newtonsoft.Json;
using Project_C_sharp_and_.NET;
using System.Collections.ObjectModel;

namespace Project_C_sharp_and_NET_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckIfSortedTest()
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

        [Theory]
        [InlineData("+32152654871","+32458963214",true)]
        [InlineData("0152654858", "+32458963259", true)]
        [InlineData("0152654848", "0458963285", true)]
        [InlineData("04152654848", "+325458963285", false)]
        [InlineData("04152654848", "+32458963285", false)]
        [InlineData("0415264848", "+324589632855", false)]
        public void CheckLenghtTest(string value1, string value2, bool value3)
        {
            string gsm = value1;
            string land = value2;
            bool expected = value3;

            bool result = BaseViewModel.CheckLenght(gsm, land);

            Assert.Equal(expected, result);
        }
    }
}