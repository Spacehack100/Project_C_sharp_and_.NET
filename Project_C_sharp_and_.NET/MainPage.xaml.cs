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
}