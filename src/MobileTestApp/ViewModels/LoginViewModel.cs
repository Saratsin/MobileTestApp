using MobileTestApp.Common.Extensions;
using MobileTestApp.Common.Utils;
using MobileTestApp.Managers.Notes;
using MobileTestApp.Managers.Users;
using MobileTestApp.Models;
using MobileTestApp.ViewModels.Abstract;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTestApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private const string DemoUserUsername = "demo";
        private static bool _isFirstCall = true;

        private readonly IUsersManager _usersManager;
        private readonly INotesManager _notesManager;

        public LoginViewModel(IUsersManager usersManager, INotesManager notesManager)
        {
            _usersManager = usersManager;
            _notesManager = notesManager;

            LoginCommand = this.CreateCommand(LoginAsync);
        }

        public ICommand LoginCommand { get; }

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value, () => Username = Username?.Trim());
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _validationText;
        public string ValidationText
        {
            get => _validationText;
            private set => SetProperty(ref _validationText, value);
        }

        protected override async Task InitializeAsync()
        {
            if (!_isFirstCall)
            {
                return;
            }

            _isFirstCall = false;

            var demoUser = await _usersManager.GetUserOrDefaultAsync(DemoUserUsername).ConfigureAwait(false);
            if (demoUser != null)
            {
                return;
            }

            await _usersManager.AddUserAsync(DemoUserUsername, "demo");
            demoUser = await _usersManager.GetUserOrDefaultAsync(DemoUserUsername).ConfigureAwait(false);

            for (var i = 0; i < 100; ++i)
            {
                var note = _notesManager.CreateRandomNoteForUser(demoUser);
                await _notesManager.AddNoteAsync(note).ConfigureAwait(false);
            }
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrEmpty(Username))
            {
                ValidationText = "Username is mandatory field";
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                ValidationText = "Password is required";
                return;
            }

            var user = await _usersManager.GetUserOrDefaultAsync(Username).ConfigureAwait(false);
            if (user is null)
            {
                ValidationText = $"User with username {Username} not found";
                return;
            }

            var isPasswordCorrect = PasswordUtils.Verify(Password, user.HashedPassword);
            if (!isPasswordCorrect)
            {
                ValidationText = "Wrong password";
                return;
            }

            ValidationText = null;
            await NavigationService.Navigate<MainViewModel, User>(user).ConfigureAwait(false);
        }
    }
}