using MobileTestApp.Entites;
using MobileTestApp.Models;

namespace MobileTestApp.Mappers
{
    public static class NoteMapper
    {
        public static Note MapToModel(this NoteEntity entity)
        {
            return new Note(entity.Id,
                            entity.UserId,
                            entity.Title,
                            entity.Subtitle,
                            entity.Description);
        }

        public static NoteEntity MapToEntity(this Note note)
        {
            return new NoteEntity
            {
                Id = note.Id,
                UserId = note.UserId,
                Title = note.Title,
                Subtitle = note.Subtitle,
                Description = note.Description
            };
        }
    }
}