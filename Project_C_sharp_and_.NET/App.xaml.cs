﻿//using CoreMotion;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Project_C_sharp_and_.NET;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        MainPage = new AppShell();

        DependencyService.Register<ApiDataStore>();
    }
}

public interface IDataStore
{
    public ObservableCollection<Item> itemList { get; set; }

    Task<String> AddItem(Item itemToAdd);
    Task<ObservableCollection<Item>> GetAllItems();
    Task<Item> GetItembyName(string name);
    Task<String> EditItem(Item itemToEdit);
    Task<String> DeleteItem(string name);
}

public class BaseViewModel : INotifyPropertyChanged
{
    public IDataStore DataStore => DependencyService.Get<IDataStore>();

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropetyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public async Task<Boolean> CheckIfExists(string name)
    {
        string nameToCheck = "";

        try
        {
            Item itemReturned = await DataStore.GetItembyName(name);
            nameToCheck = itemReturned.name.ToLower();
        }
        catch
        {
            Console.WriteLine("No contact with that name found");
        }
        
        if(nameToCheck.Equals(name.ToLower()))
        {
            return true;
        }
        else
        {
            return false;
        }  
    }

    public static Boolean CheckLenght(string gsm, string landline)
    {
        if((gsm.Length == 12 || gsm.Length == 10) && (landline.Length == 12 || landline.Length == 10))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class TestDataStore : IDataStore
{
    public ObservableCollection<Item> itemList { get; set; }

    public TestDataStore()
    {
        itemList = new ObservableCollection<Item>
        {
            new Item { name = "Jens", gsmNumber = "+32473502266", landLineNumber = "+32756985874" },
            new Item { name = "Sven", gsmNumber = "+85473502266", landLineNumber = "+85756985874" },
            new Item { name = "Martine", gsmNumber = "+54473502266", landLineNumber = "+54756985874" }
        };
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
        await DeleteItem(itemToEdit.name);
        await AddItem(itemToEdit);
        return "ok";
    }

    public async Task<String> DeleteItem(string name)
    {
        Item itemToDelete = itemList.Where(i => i.name.Equals(name)).FirstOrDefault();
        itemList.Remove(itemToDelete);
        return "Item succesfully deleted.";
    }

    public async Task<ObservableCollection<Item>> GetAllItems()
    {
        return itemList;
    }
}

class ApiDataStore : IDataStore
{
    public ObservableCollection<Item> itemList { get; set; }

    public ApiDataStore()
    {
        itemList = new ObservableCollection<Item>();
    }

    public async Task<string> AddItem(Item itemToAdd)
    {
        HttpClient client = new HttpClient();
        await client.PostAsJsonAsync("http://10.0.2.2:8000/api/item/", itemToAdd);
        return "Ok";
    }

    public async Task<Item> GetItembyName(string name)
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync("http://10.0.2.2:8000/api/item/" + name);
        return JsonConvert.DeserializeObject<Item>(response);
    }

    public async Task<String> EditItem(Item itemToEdit)
    {
        HttpClient client = new HttpClient();
        await client.PutAsJsonAsync("http://10.0.2.2:8000/api/item/" + itemToEdit.name, itemToEdit);
        return "Ok";
    }

    public async Task<string> DeleteItem(string name)
    {
        HttpClient client = new HttpClient();
        await client.DeleteAsync("http://10.0.2.2:8000/api/item/" + name);
        return "Ok";
    }

    public async Task<ObservableCollection<Item>> GetAllItems()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync("http://10.0.2.2:8000/api/item");
        return JsonConvert.DeserializeObject<ObservableCollection<Item>>(response);
    }
}

public class Item
{
    public string name { get; set; }
    public string gsmNumber { get; set; }
    public string landLineNumber { get; set; }
}