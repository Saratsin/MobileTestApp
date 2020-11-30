using MobileTestApp.Common.Utils;
using MobileTestApp.Mappers;
using MobileTestApp.Models;
using MobileTestApp.Repositories.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileTestApp.Managers.Notes
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository _notesRepository;

        public NotesManager(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<List<Note>> GetNotesByUserAsync(User user)
        {
            var noteEntities = await _notesRepository.GetAllByUserIdAsync(user.Id).ConfigureAwait(false);
            var notes = noteEntities.OrderByDescending(entity => entity.ModifiedOn.Ticks)
                                    .ThenBy(entity => entity.Title)
                                    .Select(note => note.MapToModel())
                                    .ToList();
            return notes;
        }

        public async Task<bool> DeleteNoteAsync(Note note)
        {
            var result = await _notesRepository.DeleteAsync(note.Id).ConfigureAwait(false);
            return result > 0;
        }

        public async Task<bool> AddNoteAsync(Note note)
        {
            var noteEntity = note.MapToEntity();
            var result = await _notesRepository.SaveAsync(noteEntity).ConfigureAwait(false);
            return result > 0;
        }

        public Note CreateRandomNoteForUser(User user)
        {
            var randomNote = new Note(Guid.NewGuid(),
                                      user.Id,
                                      RandomStringUtils.GenerateRandomString(8),
                                      RandomStringUtils.GenerateRandomString(16),
                                      RandomStringUtils.GenerateRandomString(48));

            return randomNote;
        }
    }
}
