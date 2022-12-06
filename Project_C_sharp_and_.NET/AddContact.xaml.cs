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
	public string nameInput { get; set; }
	public string gsmInput { get; set; }
	public string landLineInput { get; set; }

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
        await Shell.Current.GoToAsync("////MainPage");
    }

    public async void Cancel()
    {
        await Shell.Current.GoToAsync("////MainPage");
    }

	public void ClearFields()
	{
		nameInput = "";
		gsmInput = "";
		landLineInput = "";
		OnPropetyChanged();
	}
}