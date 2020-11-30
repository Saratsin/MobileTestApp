using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using System;

namespace MobileTestApp.iOS.UI.Views.Abstract.Cells
{
    public class BaseTableViewCell : MvxTableViewCell
    {
        protected BaseTableViewCell()
        {
        }

        protected BaseTableViewCell(IntPtr handle) : base(handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            InitViewCell();
            this.DelayBind(Bind);
        }

        protected virtual void InitViewCell()
        {
        }

        protected virtual void Bind()
        {
        }
    }
}