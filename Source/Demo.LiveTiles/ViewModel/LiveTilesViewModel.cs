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
