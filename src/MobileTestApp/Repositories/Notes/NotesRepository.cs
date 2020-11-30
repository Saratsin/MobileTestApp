using MobileTestApp.Entites;
using MobileTestApp.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileTestApp.Repositories.Notes
{
    public class NotesRepository : BaseRepository<NoteEntity>, INotesRepository
    {
        public override Task<int> SaveAllAsync(IEnumerable<NoteEntity> entities)
        {
            var modifiedOn = DateTime.Now;
            foreach (var entity in entities)
            {
                entity.ModifiedOn = modifiedOn;
            }

            return base.SaveAllAsync(entities);
        }

        public override Task<int> SaveAsync(NoteEntity entity)
        {
            entity.ModifiedOn = DateTime.Now;
            return base.SaveAsync(entity);
        }

        public Task<List<NoteEntity>> GetAllByUserIdAsync(Guid userId)
        {
            return GetAllAsync(entity => entity.UserId == userId);
        }
    }
}