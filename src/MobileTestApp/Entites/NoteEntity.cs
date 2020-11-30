using MobileTestApp.Entites.Abstract;
using System;

namespace MobileTestApp.Entites
{
    public class NoteEntity : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}