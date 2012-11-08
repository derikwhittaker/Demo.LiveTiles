using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Demo.LiveTiles.ViewModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Demo.LiveTiles.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ToastNotificationsPage : Demo.LiveTiles.Common.LayoutAwarePage
    {
        public ToastNotificationsPage()
        {
            this.InitializeComponent();

            DataContext = new ToastNotificationsViewModel();
        }

    }
}
