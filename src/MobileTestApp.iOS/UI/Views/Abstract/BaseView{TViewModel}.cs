using Foundation;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using System;

namespace MobileTestApp.iOS.UI.Views.Abstract
{
    public class BaseView<TViewModel> : MvxViewController<TViewModel> where TViewModel : class, IMvxViewModel
    {
        protected BaseView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        protected BaseView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitView();
            Bind();
        }

        protected virtual void InitView()
        {
        }

        protected virtual void Bind()
        {
        }
    }
}