using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI;

namespace App1.View
{
	public sealed partial class SettingsPage : Page
	{
		public SettingsPage()
		{
			this.InitializeComponent();
		}

		/// 永久化保留 标题栏颜色
		private void ThemeMode_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
			if (selectedItem != null)
			{
				string themeTag = (string)selectedItem.Tag;
				if (MainWindow.current.Content is FrameworkElement rootElement)
				{
					switch (themeTag)
					{
						case "Light":
							rootElement.RequestedTheme = ElementTheme.Light;
							MainWindow.current.AppWindow.TitleBar.ButtonForegroundColor = Colors.Black;
							break;
						case "Dark":
							rootElement.RequestedTheme = ElementTheme.Dark;
							MainWindow.current.AppWindow.TitleBar.ButtonForegroundColor = Colors.White;
							break;
						case "Default":
							rootElement.RequestedTheme = ElementTheme.Default;
							MainWindow.current.AppWindow.TitleBar.ButtonForegroundColor = Colors.DeepPink;
							break;
					}
				}
			}
		}
	}
}