using MobileTestApp.Common.Extensions;
using MobileTestApp.Common.Utils;
using MobileTestApp.Repositories.Users;
using MobileTestApp.ViewModels.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileTestApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUsersRepository _usersRepository;

        public LoginViewModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;

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

        public async Task LoginAsync()
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

            var users = await _usersRepository.GetAllAsync(user => user.Username == Username).ConfigureAwait(false);
            var user = users.FirstOrDefault();
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
            await NavigationService.Navigate<MainViewModel>().ConfigureAwait(false);
        }
    }
}