using MobileTestApp.Entites;
using MobileTestApp.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTestApp.Repositories.Notes
{
    public interface INotesRepository : IRepository<NoteEntity>
    {
        Task<List<NoteEntity>> GetAllByUserIdAsync(Guid userId);
    }
}