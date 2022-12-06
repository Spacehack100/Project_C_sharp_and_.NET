using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Project_C_sharp_and_.NET;

public partial class MainPage : ContentPage
{
	MainViewModel mvm;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = mvm = new MainViewModel();
		
	}
}

public class MainViewModel : BaseViewModel
{
	public string testString { get; set; } = "test";
	public ObservableCollection<Item> listItems { get; set; } = new ObservableCollection<Item>();
	public Command RefreshCommand { get; }
	public Command AddCommand { get; }


    public MainViewModel()
	{
		RefreshCommand = new Command(RefreshList);
		AddCommand = new Command(AddContact);

        FillList();
    }

	public async void AddContact()
	{
		await Shell.Current.GoToAsync("////AddContact");
	}

	public void RefreshList()
	{
		FillList();
	}
	public async void FillList()
    {
        listItems.Clear();
        var items = await DataStore.GetAllItems();
		foreach(Item i in items)
		{
			listItems.Add(i);
            OnPropetyChanged();
        }

    }
}