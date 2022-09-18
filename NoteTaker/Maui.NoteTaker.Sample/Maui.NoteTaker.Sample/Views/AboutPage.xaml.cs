using Maui.NoteTaker.Sample.Models;

namespace Maui.NoteTaker.Sample.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is About aboutModel)
        {
            await Launcher.Default.OpenAsync(aboutModel.MoreInfoUrl);
        }
    }
}
