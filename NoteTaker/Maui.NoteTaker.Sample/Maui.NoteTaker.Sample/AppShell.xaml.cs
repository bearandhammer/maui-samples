using Maui.NoteTaker.Sample.Views;

namespace Maui.NoteTaker.Sample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// For things not automatically registered (e.g. in the TabBar as ShellContent) we need to manually define routing
		Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
	}
}
