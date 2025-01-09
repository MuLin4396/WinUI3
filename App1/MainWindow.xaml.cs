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

namespace App1
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            ExtendsContentIntoTitleBar = true;

            SetTitleBar(AppTitleBar);
        }

        private void NavigationView_OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            // throw new NotImplementedException();
            if (ContentFrame.CanGoBack) ContentFrame.GoBack();
        }


        private void NavigationView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            throw new NotImplementedException();
            // if (args.IsSettingsInvoked)
            // {
            //     ContentFrame.Navigate(typeof())
            // }
        }

        private void ContentFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            throw new NotImplementedException();
            // NavigationView.IsBackEnabled = ContentFrame.CanGoBack;
            // if (ContentFrame.SourcePageType==)
        }
    }
}