namespace Maui.QuickStart.Sample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
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

	private void OnMultiplesBtnClicked(object sender, EventArgs e)
	{
		MultiplesBtn.Text = $"Clicked x2 equals {count * 2}";

		SemanticScreenReader.Announce(MultiplesBtn.Text);
	}
}
