using Maui.NoteTaker.Sample.Models;

namespace Maui.NoteTaker.Sample.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    private readonly string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

    public NotePage()
    {
        InitializeComponent();

        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    public string ItemId
    {
        set 
        { 
            LoadNote(value); 
        }
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
        }

        await Shell.Current.GoToAsync("..");
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
        }

        await Shell.Current.GoToAsync("..");
    }

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
