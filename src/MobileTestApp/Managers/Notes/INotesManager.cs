using MobileTestApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTestApp.Managers.Notes
{
    public interface INotesManager
    {
        Task<List<Note>> GetNotesByUserAsync(User user);

        Task<bool> DeleteNoteAsync(Note note);

        Task<bool> AddNoteAsync(Note note);

        Note CreateRandomNoteForUser(User user);
    }
}
