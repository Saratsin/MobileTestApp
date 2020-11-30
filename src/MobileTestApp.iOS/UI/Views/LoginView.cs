using MobileTestApp.iOS.UI.Views.Abstract;
using MobileTestApp.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace MobileTestApp.iOS.UI.Views
{
    [MvxRootPresentation]
    public partial class LoginView : BaseView<LoginViewModel>
    {
        public LoginView() : base(nameof(LoginView), null)
        {
        }

        protected override void Bind()
        {
            using var set = CreateBindingSet();

            set.Bind(UsernameTextField).To(vm => vm.Username);
            set.Bind(PasswordTextField).To(vm => vm.Password);
            set.Bind(ValidationLabel).To(vm => vm.ValidationText);
            set.Bind(LoginButton).To(vm => vm.LoginCommand);
        }

        public override void RemoveFromParentViewController()
        {
            base.RemoveFromParentViewController();
        }
    }
}
