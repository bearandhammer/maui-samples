using Maui.NoteTaker.Sample.Models;

namespace Maui.NoteTaker.Sample.Views;

/// <summary>
/// Represents the AllNotesPage for the NoteTaker application.
/// </summary>
/// <seealso cref="ContentPage" />
public partial class AllNotesPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AllNotesPage"/> class.
    /// </summary>
    public AllNotesPage()
    {
        InitializeComponent();

        BindingContext = new AllNotes();
    }

    /// <summary>
    /// Called when the page is 'appearing' to the user.
    /// </summary>
    protected override void OnAppearing()
    {
        ((AllNotes)BindingContext).LoadNotes();
    }

    /// <summary>
    /// Handles the Clicked event of the Add control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void Add_Clicked(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync(nameof(NotePage));

    /// <summary>
    /// Handles the SelectionChanged event of the NotesCollection control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
    private async void NotesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            Note note = (Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            NotesCollection.SelectedItem = null;
        }
    }
}
