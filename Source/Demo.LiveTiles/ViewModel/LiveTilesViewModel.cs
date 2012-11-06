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
        private ObservableCollection<LiveTileGroup> _liveTileOptions = new ObservableCollection<LiveTileGroup>();
        private LiveTileOption _selectedLiveTileOption;

        public LiveTilesViewModel()
        {
            var groups = new List<LiveTileGroup>();

            groups.Add(new LiveTileGroup
                           {
                               Name = "Square Tiles",
                               Items = new List<LiveTileOption>
                                           {
                                                                new LiveTileOption{Name = "Square Block", ImagePath = @"../Images/Tiles/TileSquareBlock.png"},
                                                                new LiveTileOption{Name = "Square Text", ImagePath = @"../Images/Tiles/TileSquareText.png"},
                                                                new LiveTileOption{Name = "Square Image Only",ImagePath = @"../Images/Tiles/TileSquareImageOnly.png",},
                                                                new LiveTileOption{Name = "Square Peek", ImagePath = @"../Images/Tiles/TileSquareImagePeek.png"},
                                           }
                           });

            groups.Add(new LiveTileGroup
                            {
                                Name = "Wide Tiles",
                                Items = new List<LiveTileOption>
                                                           {
                                                                new LiveTileOption{Name = "Wide w/ Text", ImagePath = @"../Images/Tiles/TileWideText01.png"},
                                                                new LiveTileOption{Name = "Wide w/ Image", ImagePath = @"../Images/Tiles/TileWideImage.png"},
                                                                new LiveTileOption{Name = "Wide w/ Image/Text", ImagePath = @"../Images/Tiles/TileWideImageAndText.png"},
                                                                new LiveTileOption{Name = "Wide w/ Collection", ImagePath = @"../Images/Tiles/TileWideImageCollection.png"},
                                                           }
                            });

            LiveTileOptions = new ObservableCollection<LiveTileGroup>(groups);

        }

        public ObservableCollection<LiveTileGroup> LiveTileOptions
        {
            get { return _liveTileOptions; }
            set
            {
                _liveTileOptions = value;

                RaisePropertyChanged(() => LiveTileOptions);
            }
        }

        public LiveTileOption SelectedLiveTileOption
        {
            get { return _selectedLiveTileOption; }
            set
            {
                _selectedLiveTileOption = value;

                RaisePropertyChanged(() => SelectedLiveTileOption);
            }
        }
    }
}
