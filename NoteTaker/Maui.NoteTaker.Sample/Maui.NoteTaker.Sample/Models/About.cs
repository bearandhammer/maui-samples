namespace Maui.NoteTaker.Sample.Models
{
    internal class About
    {
        public string Message => "This app is written in XAML and C# with .NET MAUI.";
        public string MoreInfoUrl => "https://aka.ms/maui";
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
    }
}
