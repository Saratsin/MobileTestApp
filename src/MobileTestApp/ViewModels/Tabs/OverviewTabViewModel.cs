using MobileTestApp.Common.Extensions;
using MobileTestApp.Managers.Notes;
using MobileTestApp.Messages;
using MobileTestApp.Models;
using MobileTestApp.ViewModels.Abstract;
using MobileTestApp.ViewModels.Tabs.Cells;
using MvvmCross.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MobileTestApp.ViewModels.Tabs
{
    public class OverviewTabViewModel : BaseViewModel, IMvxViewModel<User>
    {
        private readonly INotesManager _notesManager;

        private User _user;

        public OverviewTabViewModel(INotesManager notesManager)
        {
            _notesManager = notesManager;

            Notes = new MvxObservableCollection<NoteCellViewModel>();

            Messenger.Subscribe<NotesUpdatedMessage>(OnNotesUpdated).DisposeWith(Disposables);
        }

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

        protected override Task InitializeAsync()
        {
            return RefreshDataAsync();
        }

        private void OnNotesUpdated(NotesUpdatedMessage message)
        {
            // NOTE We can set here only flag like _refreshOnAppearing = true
            // And call data refresh only after user navigates to this tab
            // But in this case user will see small UI issue that list not updates immediately
            // Currently we have not much data so it's not crucial
            _ = SafeWrapper.WrapAsync(() => IsBusyWrapper.WrapAsync(RefreshDataAsync));
        }

        private async Task RefreshDataAsync()
        {
            var allNotes = await _notesManager.GetNotesByUserAsync(_user).ConfigureAwait(false);
            var allNoteViewModels = allNotes.Select(note => new NoteCellViewModel(note)).ToArray();

            Notes.ReplaceWith(allNoteViewModels);
        }
    }
}