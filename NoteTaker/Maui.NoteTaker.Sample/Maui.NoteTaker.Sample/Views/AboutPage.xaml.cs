using Maui.NoteTaker.Sample.Models;

namespace Maui.NoteTaker.Sample.Views;

/// <summary>
/// Represents the AboutPage for the NoteTaker application.
/// </summary>
/// <seealso cref="ContentPage" />
public partial class AboutPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutPage"/> class.
    /// </summary>
    public AboutPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Handles the Clicked event of the LearnMore control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is About aboutModel)
        {
            await Launcher.Default.OpenAsync(aboutModel.MoreInfoUrl);
        }
    }
}
