using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.LiveTiles.DataModel;
using Demo.LiveTiles.Views;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Controls;

namespace Demo.LiveTiles.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        private ObservableCollection<DashboardOption> _dashboardOptions;
        private DashboardOption _selectedDashboardOption;

        /// <summary>
        /// Initializes a new instance of the DashboardViewModel class.
        /// </summary>
        public DashboardViewModel()
        {
            DashboardOptions = new ObservableCollection<DashboardOption>(new List<DashboardOption>
                                                                             {
                                                                                 new DashboardOption{Name = "Live Tiles", Description = "Learn how to setup your application for Live Tile", 
                                                                                     ImagePath = @"../Images/LiveTileBackground.png", PageType=typeof(LiveTilesPage)},
                                                                                 new DashboardOption{Name = "Secondary Tiles", Description = "Learn how to setup/use Secondary Tiles",
                                                                                     ImagePath = @"../Images/LiveTileBackground.png", PageType=typeof(SecondaryTilesPage)},
                                                                                 new DashboardOption{Name = "Scheduled Notifications", Description = "Learn how to setup/use Scheduled Notifications",
                                                                                     ImagePath = @"../Images/LiveTileBackground.png", PageType=typeof(TileNotificationsPage)},
                                                                                 new DashboardOption{Name = "Toast Notifications", Description = "Learn how to setup/user Toast Notifications",
                                                                                     ImagePath = @"../Images/LiveTileBackground.png", PageType=typeof(ToastNotificationsPage)},
                                                                             });
        }

        public ObservableCollection<DashboardOption> DashboardOptions
        {
            get { return _dashboardOptions; }
            set
            {
                _dashboardOptions = value;

                RaisePropertyChanged(() => DashboardOptions);
            }
        }

        public DashboardOption SelectedDashboardOption
        {
            get { return _selectedDashboardOption; }
            set
            {
                _selectedDashboardOption = value;

                RaisePropertyChanged(() => SelectedDashboardOption);

                NavigateToSelectedPage();
            }
        }

        private void NavigateToSelectedPage()
        {
            var currentFrame = Windows.UI.Xaml.Window.Current;
            var frame = currentFrame.Content as Frame;

            var args = new Dictionary<string, string>{};

            frame.Navigate(SelectedDashboardOption.PageType, args);
        }
    }
}