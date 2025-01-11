using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using App1.View;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml.Media.Animation;
using WinUIEx;

namespace App1
{
	public sealed partial class MainWindow : Window
	{
		private const int WindowMinWidth = 960;
		private const int WindowMinHeight = 540;

		public MainWindow()
		{
			InitializeComponent();

			var manager = WindowManager.Get(this);
			manager.MinWidth = WindowMinWidth;
			manager.MinHeight = WindowMinHeight;

			NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems.OfType<NavigationViewItem>().First();
			ContentFrame.Navigate(typeof(HomePage), null, new EntranceNavigationTransitionInfo());

			SystemBackdrop = new MicaBackdrop { Kind = MicaKind.BaseAlt };

			ExtendsContentIntoTitleBar = true;
			SetTitleBar(AppTitleBar);
		}

		private string GetAppTitleFromSystem()
		{
			return Windows.ApplicationModel.Package.Current.DisplayName;
		}

		private void NavigationView_OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
		{
			if (ContentFrame.CanGoBack) ContentFrame.GoBack();
		}


		private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			if (args.IsSettingsInvoked)
			{
				ContentFrame.Navigate(typeof(SettingsPage), null, args.RecommendedNavigationTransitionInfo);
			}
			else if (args.InvokedItemContainer != null && (args.InvokedItemContainer.Tag != null))
			{
				Type newPage = Type.GetType(args.InvokedItemContainer.Tag.ToString());
				ContentFrame.Navigate(newPage, null, args.RecommendedNavigationTransitionInfo);
			}
		}

		private void ContentFrame_OnNavigated(object sender, NavigationEventArgs e)
		{
			NavigationViewControl.IsBackEnabled = ContentFrame.CanGoBack;
			if (ContentFrame.SourcePageType == typeof(SettingsPage))
			{
				NavigationViewControl.SelectedItem = (NavigationViewItem)NavigationViewControl.SettingsItem;
			}
			else if (ContentFrame.SourcePageType != null)
			{
				NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems.OfType<NavigationViewItem>().First(n => n.Tag.Equals(ContentFrame.SourcePageType.FullName.ToString()));
			}
		}
	}
}