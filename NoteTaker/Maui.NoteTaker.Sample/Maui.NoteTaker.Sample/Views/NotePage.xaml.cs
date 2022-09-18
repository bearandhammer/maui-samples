using Maui.NoteTaker.Sample.Models;

namespace Maui.NoteTaker.Sample.Views;

public partial class NotePage : ContentPage
{
    private readonly string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

    public NotePage()
    {
        InitializeComponent();

        if (File.Exists(fileName))
        {
            TextEditor.Text = File.ReadAllText(fileName);
        }
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        TextEditor.Text = string.Empty;
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        File.WriteAllText(fileName, TextEditor.Text);
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
