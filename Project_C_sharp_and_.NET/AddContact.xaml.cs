namespace Project_C_sharp_and_.NET;

public partial class AddContact : ContentPage
{
	AddContactViewModel acvm;

	public AddContact()
	{
		InitializeComponent();
		BindingContext= acvm = new AddContactViewModel();
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
		Item itemToAdd = new Item() { name=nameInput, gsmNumber=gsmInput, landLineNumber=landLineInput };
		await DataStore.AddItem(itemToAdd);
		ClearFields();
        await Shell.Current.GoToAsync("////MainPage");
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