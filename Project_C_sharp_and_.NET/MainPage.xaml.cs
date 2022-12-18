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
    protected override void OnAppearing()
    {
        base.OnAppearing();
        mvm.RefreshList();
    }

    public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
	{
		mvm.OnItemSelected();
    }
}

public class MainViewModel : BaseViewModel
{
	ObservableCollection<Item> _listItems = new ObservableCollection<Item>();

    public ObservableCollection<Item> listItems { get { return _listItems; } set { _listItems = value; OnPropetyChanged(); } }
	public Item selectedItem { get; set; }
	public Command RefreshCommand { get; }
	public Command AddCommand { get; }

    public MainViewModel()
	{
		RefreshCommand = new Command(RefreshList);
		AddCommand = new Command(AddContact);
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
        listItems = await DataStore.GetAllItems();
		listItems = sortList(listItems);
    }

	public async void OnItemSelected()
	{
		if (selectedItem != null)
		{
			var navigationParameter = new Dictionary<string, object>
			{
				{"Contact", selectedItem }
			};
			await Shell.Current.GoToAsync("////EditContact", navigationParameter);
		}
	}

	public static ObservableCollection<Item> sortList(ObservableCollection<Item> items)
	{
		ObservableCollection<Item> sortedList = new ObservableCollection<Item>(items.OrderBy(i => i.name));
		return sortedList;
	}
}