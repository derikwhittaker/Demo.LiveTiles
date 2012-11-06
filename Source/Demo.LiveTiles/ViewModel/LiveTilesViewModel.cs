using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.LiveTiles.DataModel;
using Demo.LiveTiles.Views;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Controls;


namespace Demo.LiveTiles.ViewModel
{
    public class LiveTilesViewModel : ViewModelBase
    {
        private ObservableCollection<LiveTileOption> _liveTileOptions = new ObservableCollection<LiveTileOption>();

        public LiveTilesViewModel()
        {
            LiveTileOptions = new ObservableCollection<LiveTileOption>(new List<LiveTileOption>
                                                                             {
                                                                                 new LiveTileOption{Name = "Live Tiles", 
                                                                                     ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                 new LiveTileOption{Name = "Secondary Tiles",
                                                                                     ImagePath = @"../Images/LiveTileBackground.png",},
                                                                                 new LiveTileOption{Name = "Tile Notifications",
                                                                                     ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                 new LiveTileOption{Name = "Toast Notifications", 
                                                                                     ImagePath = @"../Images/LiveTileBackground.png"},
                                                                             });

        }

        public ObservableCollection<LiveTileOption> LiveTileOptions
        {
            get { return _liveTileOptions; }
            set
            {
                _liveTileOptions = value;

                RaisePropertyChanged(() => LiveTileOptions);
            }
        }
    }
}
