namespace Project_C_sharp_and_.NET;

public partial class AddContact : ContentPage
{
	AddContactViewModel acvm;

	public AddContact()
	{
		InitializeComponent();
		BindingContext= acvm = new AddContactViewModel();
	}

	public async void Alerts(string message)
	{
		await DisplayAlert("Alert", message, "OK");
	}
}

public class AddContactViewModel : BaseViewModel
{
	string _nameInput = string.Empty;
    string _gsmInput = string.Empty;
	string _landLineInput = string.Empty;

    public string nameInput { get { return _nameInput; } set { _nameInput = value; OnPropetyChanged(); } }
	public string gsmInput { get { return _gsmInput; } set { _gsmInput = value; OnPropetyChanged(); } }
    public string landLineInput { get { return _landLineInput; } set { _landLineInput = value; OnPropetyChanged(); } }

    public Command ConfirmCommand { get; }
    public Command CancelCommand { get; }

	public AddContactViewModel() 
	{
		ConfirmCommand = new Command(SaveItem);
		CancelCommand = new Command(Cancel);
	}

	public async void SaveItem()
	{
		bool exists = await CheckIfExists(nameInput);
		if(exists == false)
		{
			Item itemToAdd = new Item() { name=nameInput, gsmNumber=gsmInput, landLineNumber=landLineInput };
			await DataStore.AddItem(itemToAdd);
			ClearFields();
			await Shell.Current.GoToAsync("////MainPage");
		}
		else
		{
			await App.Current.MainPage.DisplayAlert("Alert", "Contact already exists", "OK");
		}
    }

    public async void Cancel()
    {
		ClearFields();
        await Shell.Current.GoToAsync("////MainPage");
    }

	public void ClearFields()
	{
		nameInput = "";
        gsmInput = "";
        landLineInput = "";
	}
}