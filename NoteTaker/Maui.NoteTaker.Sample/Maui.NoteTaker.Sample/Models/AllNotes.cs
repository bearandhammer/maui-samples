using System.Collections.ObjectModel;

namespace Maui.NoteTaker.Sample.Models
{
    /// <summary>
    /// Internal class acting as a model for the AllNotesPage.
    /// </summary>
    internal class AllNotes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllNotes"/> class.
        /// </summary>
        internal AllNotes() => LoadNotes();

        /// <summary>
        /// Gets or sets the Notes to show on the AllNotesPage.
        /// </summary>
        internal ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        /// <summary>
        /// Public utility method responsible for loading notes (stored as a file on the device).
        /// </summary>
        internal void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Note> notes = Directory
                // Select the file names from the directory
                .EnumerateFiles(appDataPath, "*.notes.txt")
                // Each file name is used to create a new Note
                .Select(filename => new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                })
                // With the final collection of notes, order them by date
                .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (Note note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
