﻿using Demo.LiveTiles.Data;
using System;
using System.Collections.Generic;
using Demo.LiveTiles.ViewModel;
using Windows.UI.Xaml.Controls;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace Demo.LiveTiles.Views
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class DashbaordPage : Demo.LiveTiles.Common.LayoutAwarePage
    {
        public DashbaordPage()
        {
            this.InitializeComponent();
            DataContext = new DashboardViewModel();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            
        }

    }
}