using MobileTestApp.Common;
using MobileTestApp.iOS.UI.Views.Abstract;
using MobileTestApp.iOS.UI.Views.Tabs.Cells;
using MobileTestApp.ViewModels.Tabs;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using UIKit;

namespace MobileTestApp.iOS.UI.Views.Tabs
{
    [MvxTabPresentation(TabIconName = "ic_tab_edit", TabName = Constants.Tabs.Edit)]
    public partial class EditTabView : BaseView<EditTabViewModel>
    {
        private MvxTableViewSource _notesSource;
        private UIBarButtonItem _addButton;
        private UIBarButtonItem _deleteButton;

        public EditTabView() : base(nameof(EditTabView), null)
        {
        }

        protected override void InitView()
        {
            _notesSource = new MvxSimpleTableViewSource(TableView, nameof(NoteCell), NoteCell.Key) { UseAnimations = true };
            TableView.Source = _notesSource;

            _addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            _deleteButton = new UIBarButtonItem("Delete", null);

            NavigationItem.SetRightBarButtonItems(new[] { _addButton, _deleteButton }, false);
        }

        protected override void Bind()
        {
            using var set = CreateBindingSet();

            set.Bind(NavigationItem).For(v => v.Title).To(vm => vm.Title);
            set.Bind(_notesSource).To(vm => vm.Notes);
            set.Bind(_addButton).For(v => v.BindClicked()).To(vm => vm.AddRandomNoteCommand);
            set.Bind(_deleteButton).For(v => v.BindClicked()).To(vm => vm.DeleteLastNoteCommand);
        }
    }
}