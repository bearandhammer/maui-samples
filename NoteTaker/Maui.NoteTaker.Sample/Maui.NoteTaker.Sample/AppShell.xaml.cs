using Maui.NoteTaker.Sample.Views;

namespace Maui.NoteTaker.Sample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
	}
}
