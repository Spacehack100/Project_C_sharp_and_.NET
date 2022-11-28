//using CoreMotion;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Project_C_sharp_and_.NET;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		DependencyService.Register<TestDataStore>();
		MainPage = new AppShell();
	}
}

public interface IDataStore
{
	public List<Item> itemList { get; set; }

	Task<String> AddItem(Item itemToAdd);
    Task<List<Item>> GetAllItems();
	Task<Item> GetItembyName(string name);
	Task<String> EditItem(Item itemToEdit);
	Task<String> DeleteItem(string name);
}

public class BaseViewModel : INotifyPropertyChanged
{
	public IDataStore DataStore => DependencyService.Get<IDataStore>();

    public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropetyChanged([CallerMemberName] string name=null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}

class TestDataStore : IDataStore
{
	public List<Item> itemList { get; set; }
    
	public TestDataStore()
	{
		itemList = new List<Item>();
	}

    public async Task<String> AddItem(Item itemToAdd)
	{
        itemList.Add(itemToAdd);
        return "Item succesfully added.";
	}

    public async Task<Item> GetItembyName(string name)
	{
        Item temp = new Item();
        temp = itemList.Where(i => i.name.Equals(name)).FirstOrDefault();
        return temp;
    }

    public async Task<String> EditItem(Item itemToEdit)
	{
        return "ok";
    }

    public async Task<String> DeleteItem(string name)
	{
        Item itemToDelete = itemList.Where(i => i.name.Equals(name)).FirstOrDefault();

        return "not done";
    }

    public async Task<List<Item>> GetAllItems()
    {
        return itemList;
    }
}

class ApiDataStore : IDataStore
{
    public List<Item> itemList { get; set; }

    public ApiDataStore()
    {
        itemList = new List<Item>();
    }

    public async Task<string> AddItem(Item itemToAdd)
    {
        HttpClient client = new HttpClient();
        string addString = JsonConvert.SerializeObject(itemToAdd);
        await client.PostAsJsonAsync("http://10.0.2.2:8000/api/item/", addString);
        return "Ok";
    }

    public async Task<Item> GetItembyName(string name)
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync("http://10.0.2.2:8000/api/item/" + name);
        Item temp = new Item();
        return temp;
    }

    public async Task<String> EditItem(Item itemToEdit)
    {
        HttpClient client = new HttpClient();
        string addString = JsonConvert.SerializeObject(itemToEdit);
        await client.PutAsJsonAsync("http://10.0.2.2:8000/api/item/" + itemToEdit.name, addString);
        return "Ok";
    }

    public async Task<string> DeleteItem(string name)
    {
        HttpClient client = new HttpClient();
        await client.DeleteAsync("http://10.0.2.2:8000/api/item/" + name);
        return "Ok";
    }

    public async Task<List<Item>> GetAllItems()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync("http://10.0.2.2:8000/api/item");
        return JsonConvert.DeserializeObject<List<Item>>(response);
    }

}

public struct Item
{
	public string name { get; set; }
	public int gsmNumber { get; set; }
    public int landLineNumber { get; set; }
}