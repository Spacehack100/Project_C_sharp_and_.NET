using CoreMotion;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

	String AddItem(Item itemToAdd);
	Item GetItembyName(string name);
	String EditItem(string name);
	String DeleteItem(string name);
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

    public String AddItem(Item itemToAdd)
	{
		return "not done";
	}

    public Item GetItembyName(string name)
	{
        Item temp = new Item();
        return temp;
    }

    public String EditItem(string name)
	{
        return "not done";
    }

    public String DeleteItem(string name)
	{
        return "not done";
    }
}

class ApiDataStore : IDataStore
{
    public List<Item> itemList { get; set; }

    public ApiDataStore()
    {
        itemList = new List<Item>();
    }

    public String AddItem(Item itemToAdd)
    {
        return "not done";
    }

    public Item GetItembyName(string name)
    {
		Item temp = new Item();
        return temp;
    }

    public String EditItem(string name)
    {
        return "not done";
    }

    public String DeleteItem(string name)
    {
        return "not done";
    }
}

public struct Item
{
	string name { get; set; }
	int value1 { get; set; }
	int value2 { get; set; }
	string value3 { get; set; }
}