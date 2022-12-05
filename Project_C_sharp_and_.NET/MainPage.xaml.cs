using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Project_C_sharp_and_.NET;

public partial class MainPage : ContentPage
{
	int count = 0;
	MainViewModel mvm;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = mvm = new MainViewModel();

	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

public class MainViewModel : BaseViewModel
{
	public string testString { get; set; } = "test";
	public ObservableCollection<Item> listItems { get; set; } = new ObservableCollection<Item>();
	public Command RefreshCommand { get; }

	public MainViewModel()
	{
		RefreshCommand = new Command(RefreshList);
		FillList();

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