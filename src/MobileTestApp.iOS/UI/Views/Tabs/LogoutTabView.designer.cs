// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MobileTestApp.iOS.UI.Views.Tabs
{
	[Register ("LogoutTabView")]
	partial class LogoutTabView
	{
		[Outlet]
		UIKit.UIButton LogoutButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LogoutButton != null) {
				LogoutButton.Dispose ();
				LogoutButton = null;
			}
		}
	}
}
