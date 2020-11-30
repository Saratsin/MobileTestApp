using MobileTestApp.Common.Extensions;
using MobileTestApp.Managers.Notes;
using MobileTestApp.Messages;
using MobileTestApp.Models;
using MobileTestApp.ViewModels.Abstract;
using MobileTestApp.ViewModels.Tabs.Cells;
using MvvmCross.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTestApp.ViewModels.Tabs
{
    public class EditTabViewModel : BaseViewModel, IMvxViewModel<User>
    {
        private readonly INotesManager _notesManager;

        private User _user;

        public EditTabViewModel(INotesManager notesManager)
        {
            _notesManager = notesManager;

            Notes = new MvxObservableCollection<NoteCellViewModel>();

            AddRandomNoteCommand = this.CreateCommand(AddRandomNoteAsync);
            DeleteLastNoteCommand = this.CreateCommand(DeleteLastNoteAsync);
        }

        public ICommand AddRandomNoteCommand { get; }
        public ICommand DeleteLastNoteCommand { get; }

        public MvxObservableCollection<NoteCellViewModel> Notes { get; }

        private string _title;
        public string Title
        {
            get => _title;
            private set => SetProperty(ref _title, value);
        }

        public void Prepare(User parameter)
        {
            Title = parameter.Username;
            _user = parameter;
        }

        protected override async Task InitializeAsync()
        {
            var notes = await _notesManager.GetNotesByUserAsync(_user).ConfigureAwait(false);
            var noteViewModels = notes.Select(note => new NoteCellViewModel(note)).ToList();
            Notes.ReplaceWith(noteViewModels);
        }

        private async Task AddRandomNoteAsync()
        {
            var note = _notesManager.CreateRandomNoteForUser(_user);
            var isNoteAdded = await _notesManager.AddNoteAsync(note).ConfigureAwait(false);
            if (!isNoteAdded)
            {
                throw new Exception("Failed to add random note");
            }

            var noteViewModel = new NoteCellViewModel(note);
            Notes.Insert(0, noteViewModel);

            Messenger.Publish(new NotesUpdatedMessage(this));
        }

        private async Task DeleteLastNoteAsync()
        {
            // NOTE We have reversed list so first note is actually the last note
            var lastNoteViewModel = Notes.FirstOrDefault();
            if (lastNoteViewModel is null)
            {
                return;
            }

            var lastNote = lastNoteViewModel.Note;
            var isNoteDeleted = await _notesManager.DeleteNoteAsync(lastNote).ConfigureAwait(false);
            if (!isNoteDeleted)
            {
                throw new Exception("Failed to delete last note");
            }

            Notes.Remove(lastNoteViewModel);

            Messenger.Publish(new NotesUpdatedMessage(this));
        }
    }
}