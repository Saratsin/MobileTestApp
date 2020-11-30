using MobileTestApp.Common;
using MobileTestApp.iOS.UI.Views.Abstract;
using MobileTestApp.iOS.UI.Views.Tabs.Cells;
using MobileTestApp.ViewModels.Tabs;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using UIKit;

namespace MobileTestApp.iOS.UI.Views.Tabs
{
    [MvxTabPresentation(TabIconName = "ic_tab_overview", TabName = Constants.Tabs.Overview)]
    public partial class OverviewTabView : BaseView<OverviewTabViewModel>
    {
        private MvxTableViewSource _notesSource;

        public OverviewTabView() : base(nameof(OverviewTabView), null)
        {
        }

        protected override void InitView()
        {
            _notesSource = new MvxSimpleTableViewSource(TableView, nameof(NoteCell), NoteCell.Key) { UseAnimations = true };
            TableView.Source = _notesSource;
        }

        protected override void Bind()
        {
            using var set = CreateBindingSet();

            set.Bind(NavigationItem).For(v => v.Title).To(vm => vm.Title);
            set.Bind(_notesSource).To(vm => vm.Notes);
        }
    }
}