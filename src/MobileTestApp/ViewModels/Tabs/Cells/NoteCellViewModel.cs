using MobileTestApp.Models;
using System;
using System.Collections.Generic;

namespace MobileTestApp.ViewModels.Tabs.Cells
{
    public class NoteCellViewModel : IEquatable<NoteCellViewModel>
    {
        public NoteCellViewModel(Note note)
        {
            Note = note;
        }

        public Note Note { get; }

        public string Title => Note.Title;

        public string Subtitle => Note.Subtitle;

        public string Description => Note.Description;

        public override bool Equals(object obj)
        {
            return Equals(obj as NoteCellViewModel);
        }

        public bool Equals(NoteCellViewModel other)
        {
            return other != null &&
                   EqualityComparer<Note>.Default.Equals(Note, other.Note);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Note);
        }
    }
}
