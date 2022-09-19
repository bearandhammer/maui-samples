using Maui.NoteTaker.Sample.Models;

namespace Maui.NoteTaker.Sample.Views;

/// <summary>
/// Represents the NotePage for the NoteTaker application. Note the <see cref="ItemId"/> that
/// is configured as a navigation <see cref="QueryPropertyAttribute"/>.
/// </summary>
/// <seealso cref="ContentPage" />
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotePage"/> class.
    /// </summary>
    public NotePage()
    {
        InitializeComponent();

        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    /// <summary>
    /// Sets the ItemId representing the note to be loaded.
    /// </summary>
    public string ItemId
    {
        set
        {
            LoadNote(value);
        }
    }

    /// <summary>
    /// Handles the Clicked event of the DeleteButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
        }

        await Shell.Current.GoToAsync("..");
    }

    /// <summary>
    /// Handles the Clicked event of the SaveButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
        }

        await Shell.Current.GoToAsync("..");
    }

    /// <summary>
    /// Loads an individual note based on the supplied file name.
    /// </summary>
    /// <param name="fileName">The file name of the note to load.</param>
    private void LoadNote(string fileName)
    {
        Note noteModel = new Note
        {
            Filename = fileName
        };

        if (File.Exists(noteModel.Filename))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}
