using System;

namespace MobileTestApp.Models
{
    public class Note : IEquatable<Note>
    {
        public Note(Guid id,
                    Guid userId,
                    string title,
                    string subtitle,
                    string description)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Subtitle = subtitle;
            Description = description;
        }

        public Guid Id { get; }

        public Guid UserId { get; }

        public string Title { get; }

        public string Subtitle { get; }

        public string Description { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Note);
        }

        public bool Equals(Note other)
        {
            return other != null &&
                   Id == other.Id &&
                   UserId == other.UserId &&
                   Title == other.Title &&
                   Subtitle == other.Subtitle &&
                   Description == other.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}