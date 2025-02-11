using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
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
							UpdateTitleBarButtonColor(ElementTheme.Light);
							break;
						case "Dark":
							rootElement.RequestedTheme = ElementTheme.Dark;
							UpdateTitleBarButtonColor(ElementTheme.Dark);
							break;
						case "Default":
							rootElement.RequestedTheme = ElementTheme.Default;
							UpdateTitleBarButtonColor(rootElement.ActualTheme);
							break;
					}
				}
			}
		}

		private void UpdateTitleBarButtonColor(ElementTheme theme)
		{
			switch (theme)
			{
				case ElementTheme.Light:
					MainWindow.current.AppWindow.TitleBar.ButtonForegroundColor = Colors.Black;
					break;
				case ElementTheme.Dark:
					MainWindow.current.AppWindow.TitleBar.ButtonForegroundColor = Colors.White;
					break;
			}
		}
	}
}