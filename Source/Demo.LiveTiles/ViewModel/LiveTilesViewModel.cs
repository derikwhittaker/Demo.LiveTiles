using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.LiveTiles.DataModel;
using GalaSoft.MvvmLight;
using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;


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
                                                new LiveTileOption{ LiveTileType = LiveTileType.SquareText, Name = "Square Text", ImagePath = @"../Images/Tiles/TileSquareText.png"},
                                                new LiveTileOption{ LiveTileType = LiveTileType.SquareImageOnly, Name = "Square Image Only",ImagePath = @"../Images/Tiles/TileSquareImageOnly.png",},
                                                new LiveTileOption{ LiveTileType = LiveTileType.SquareBlock, Name = "Square Block", ImagePath = @"../Images/Tiles/TileSquareBlock.png"},
                                                new LiveTileOption{ LiveTileType = LiveTileType.SquareImagePeek, Name = "Square Peek", ImagePath = @"../Images/Tiles/TileSquareImagePeek.png"},
                                           }
                           });

            groups.Add(new LiveTileGroup
                            {
                                Name = "Wide Tiles",
                                Items = new List<LiveTileOption>
                                                           {
                                                new LiveTileOption{ LiveTileType = LiveTileType.WideText, Name = "Wide w/ Text", ImagePath = @"../Images/Tiles/TileWideText01.png"},                                                                
                                                new LiveTileOption{ LiveTileType = LiveTileType.WideImageAndText, Name = "Wide w/ Image/Text", ImagePath = @"../Images/Tiles/TileWideImageAndText.png"},
                                                new LiveTileOption{ LiveTileType = LiveTileType.WideImage, Name = "Wide w/ Image", ImagePath = @"../Images/Tiles/TileWideImage.png"},
                                                new LiveTileOption{ LiveTileType = LiveTileType.WideImageCollection, Name = "Wide w/ Collection", ImagePath = @"../Images/Tiles/TileWideImageCollection.png"},
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

                CreateTile();
            }
        }

        private void CreateTile()
        {
            switch (SelectedLiveTileOption.LiveTileType)
            {
                case LiveTileType.SquareText:
                    CreateSquareTextTile();
                    break;

                case LiveTileType.SquareBlock:
                    CreateSquareBlockTile();
                    break;

                case LiveTileType.SquareImageOnly:
                    CreateSquareImageTile();
                    break;

                case LiveTileType.SquareImagePeek:
                    CreateSquareImagePeekTile();
                    break;

                case LiveTileType.WideImage:
                    CreateWideTile();
                    break;

                case LiveTileType.WideImageAndText:
                    CreateWideImageAndTextTile();
                    break;

                case LiveTileType.WideImageCollection:
                    CreateWideImageCollectionTile();
                    break;

                case LiveTileType.WideText:
                    CreateWideTextTile();
                    break;
            }
        }

        private void CreateSquareTextTile()
        {
            
        }

        private void CreateSquareBlockTile()
        {
       
        }

        private void CreateSquareImageTile()
        {
 
        }

        private void CreateSquareImagePeekTile()
        {
        
        }

        private void CreateWideTile()
        {

        }

        private void CreateWideImageAndTextTile()
        {
     
        }

        private void CreateWideImageCollectionTile()
        {

        }

        private void CreateWideTextTile()
        {
        }
    }
}
