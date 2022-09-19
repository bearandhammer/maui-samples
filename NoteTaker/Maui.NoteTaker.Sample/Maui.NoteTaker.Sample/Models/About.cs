namespace Maui.NoteTaker.Sample.Models
{
    /// <summary>
    /// Internal class acting as a model for the AboutPage.
    /// </summary>
    internal class About
    {
        /// <summary>
        /// Gets the stock message for the AboutPage.
        /// </summary>
        internal string Message => "This app is written in XAML and C# with .NET MAUI.";

        /// <summary>
        /// Gets the more info URL for the AboutPage.
        /// </summary>
        internal string MoreInfoUrl => "https://aka.ms/maui";

        /// <summary>
        /// Gets the application title for the AboutPage.
        /// </summary>
        internal string Title => AppInfo.Name;

        /// <summary>
        /// Gets the application version for the AboutPage.
        /// </summary>
        internal string Version => AppInfo.VersionString;
    }
}
