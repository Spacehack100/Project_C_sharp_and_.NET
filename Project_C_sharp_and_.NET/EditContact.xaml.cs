namespace Project_C_sharp_and_.NET;

public partial class EditContact : ContentPage
{
    EditContactViewModel ecvm;

    public EditContact()
    {
        InitializeComponent();
        BindingContext = ecvm = new EditContactViewModel();
    }
}

public class EditContactViewModel : BaseViewModel, IQueryAttributable
{
    string _nameInput = string.Empty;
    string _gsmInput = string.Empty;
    string _landLineInput = string.Empty;
    Item _itemToEdit = new Item();

    public string nameInput { get { return _nameInput; } set { _nameInput = value; OnPropetyChanged(); } }
    public string gsmInput { get { return _gsmInput; } set { _gsmInput = value; OnPropetyChanged(); } }
    public string landLineInput { get { return _landLineInput; } set { _landLineInput = value; OnPropetyChanged(); } }
    public string originalInput { get; set; }
    public Item itemToEdit { get { return _itemToEdit; } set { _itemToEdit = value; OnPropetyChanged(); } }

    public Command ConfirmCommand { get; }
    public Command CancelCommand { get; }
    public Command DeleteCommand { get; }

    public EditContactViewModel()
    {
        ConfirmCommand = new Command(SaveItem);
        CancelCommand = new Command(Cancel);
        DeleteCommand = new Command(Delete);
    }

    public async void SaveItem()
    {
        bool exists = await CheckIfExists(nameInput);
        if (exists == true)
        {
            Item itemToSave = new Item() { name = nameInput, gsmNumber = gsmInput, landLineNumber = landLineInput };
            await DataStore.EditItem(itemToSave);
            ClearFields();
            await Shell.Current.GoToAsync("////MainPage");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Contact doesn't exists. No changes can be applied", "OK");
        }
    }

    public async void Cancel()
    {
        ClearFields();
        await Shell.Current.GoToAsync("////MainPage");
    }

    public async void Delete()
    {
        await DataStore.DeleteItem(nameInput);
        ClearFields();
        await Shell.Current.GoToAsync("////MainPage");
    }

    public void ClearFields()
    {
        nameInput = "";
        gsmInput = "";
        landLineInput = "";
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        itemToEdit = query["Contact"] as Item;
        nameInput = itemToEdit.name;
        gsmInput = itemToEdit.gsmNumber;
        landLineInput = itemToEdit.landLineNumber;
    }
}