using System;

using Foundation;
using MobileTestApp.iOS.UI.Views.Abstract.Cells;
using MobileTestApp.ViewModels.Tabs.Cells;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace MobileTestApp.iOS.UI.Views.Tabs.Cells
{
    public partial class NoteCell : BaseTableViewCell
    {
        public static readonly NSString Key = new NSString(nameof(NoteCell));
        public static readonly UINib Nib;

        static NoteCell()
        {
            Nib = UINib.FromName(nameof(NoteCell), NSBundle.MainBundle);
        }

        protected NoteCell(IntPtr handle) : base(handle)
        {
        }

        protected override void Bind()
        {
            using var set = this.CreateBindingSet<NoteCell, NoteCellViewModel>();

            set.Bind(TitleLabel).To(vm => vm.Title);
            set.Bind(SubtitleLabel).To(vm => vm.Subtitle);
            set.Bind(DescriptionLabel).To(vm => vm.Description);
        }
    }
}