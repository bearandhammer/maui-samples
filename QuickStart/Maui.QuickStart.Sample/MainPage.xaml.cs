namespace Maui.QuickStart.Sample;

/// <summary>
/// References the main content page for this application.
/// </summary>
/// <seealso cref="ContentPage" />
public partial class MainPage : ContentPage
{
    /// <summary>
    /// Tracking count representing the amount of times the 'counter' button is clicked.
    /// </summary>
    private int count = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Event method called when the 'CounterBtn' is clicked.
    /// </summary>
    /// <param name="sender">The sender object triggering this event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        CounterBtn.Text = count == 1
            ? $"Clicked {count} time"
            : $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    /// <summary>
    /// Event method called when the 'CounterBtn' is clicked.
    /// </summary>
    /// <param name="sender">The sender object triggering this event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void OnMultiplesBtnClicked(object sender, EventArgs e)
    {
        MultiplesBtn.Text = $"Clicked x2 equals {count * 2}";

        SemanticScreenReader.Announce(MultiplesBtn.Text);
    }
}
