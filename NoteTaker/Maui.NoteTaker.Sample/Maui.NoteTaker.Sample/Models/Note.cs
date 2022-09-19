namespace Maui.NoteTaker.Sample.Models
{
    /// <summary>
    /// Internal class acting as a model for the AllNotesPage.
    /// </summary>
    internal class Note
    {
        /// <summary>
        /// Gets or sets the date the note was saved.
        /// </summary>
        internal DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the filename of the note.
        /// </summary>
        /// <value>
        internal string Filename { get; set; }

        /// <summary>
        /// Gets or sets the text of the note.
        /// </summary>
        internal string Text { get; set; }
    }
}
