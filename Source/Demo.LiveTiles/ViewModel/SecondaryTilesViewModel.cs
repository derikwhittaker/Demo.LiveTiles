using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.LiveTiles.DataModel;
using Demo.LiveTiles.Managers;
using GalaSoft.MvvmLight;

namespace Demo.LiveTiles.ViewModel
{
    public class SecondaryTilesViewModel : ViewModelBase
    {

        public const string TileIdPattern = "SecondaryTilePage.{0}.{1}";
        private IPinManager _pinManager = new PinManager();
        private ObservableCollection<SecondaryTileOption> _secondaryTileOptions;
        private SecondaryTileOption _selectedSecondaryTileOption;
        private bool _showPageArguments;
        private string _arg1;
        private string _arg2;

        public SecondaryTilesViewModel()
        {
            SecondaryTileOptions = new ObservableCollection<SecondaryTileOption>(new List<SecondaryTileOption>
                                                                             {
                                                                                 new SecondaryTileOption{Name = "Simple Solution", SecondaryTileType = SecondaryTileType.Simple, 
                                                                                     ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                 new SecondaryTileOption{Name = "With Parameters", SecondaryTileType = SecondaryTileType.WithParameters,
                                                                                     ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                     new SecondaryTileOption{Name = "Secondary Live Tile", SecondaryTileType = SecondaryTileType.LiveSecondaryTile,
                                                                                     ImagePath = @"../Images/LiveTileBackground.png"},  
                                                                             });

        }

        public ObservableCollection<SecondaryTileOption> SecondaryTileOptions
        {
            get { return _secondaryTileOptions; }
            set
            {
                _secondaryTileOptions = value;

                RaisePropertyChanged(() => SecondaryTileOptions);
            }
        }

        public SecondaryTileOption SelectedSecondaryTileOption
        {
            get { return _selectedSecondaryTileOption; }
            set
            {
                _selectedSecondaryTileOption = value;

                RaisePropertyChanged(() => SelectedSecondaryTileOption);

                CreateSecondaryTile();
            }
        }

        private void CreateSecondaryTile()
        {
            switch (SelectedSecondaryTileOption.SecondaryTileType)
            {
                case SecondaryTileType.LiveSecondaryTile:
                    PinLiveTile();
                    break;

                case SecondaryTileType.Simple:
                    PinSimpleTile();
                    break;

                case SecondaryTileType.WithParameters:
                    PinTileWithParameters();
                    break;
            }
        }

        public bool ShowPageArguments
        {
            get { return _showPageArguments; }
            set
            {
                _showPageArguments = value;

                RaisePropertyChanged(() => ShowPageArguments);
            }
        }

        public string Arg1
        {
            get { return _arg1; }
            set
            {
                _arg1 = value;
                RaisePropertyChanged(() => Arg1);
            }
        }

        public string Arg2
        {
            get { return _arg2; }
            set
            {
                _arg2 = value;
                RaisePropertyChanged(() => Arg2);
            }
        }

        private string BuildPinId( SecondaryTileType secondaryTileType )
        {
            if (secondaryTileType == SecondaryTileType.Simple)
            {
                return string.Format(TileIdPattern, "Simple", "Simple");
            }
            
            if (secondaryTileType == SecondaryTileType.WithParameters)
            {
                return string.Format(TileIdPattern, "Complex", "WithParameters");    
            }

            return string.Format(TileIdPattern, "Live", "NoParms");
        }


        private async void PinLiveTile()
        {
            var tileId = BuildPinId(SecondaryTileType.LiveSecondaryTile);

            if (_pinManager.IsPinned(tileId))
            {
                await _pinManager.UnPin(tileId);
            }

            var args = "SecondaryTilePage=Arg1|Arg2";

            await _pinManager.Pin("Live Secondary", "Parameters Desc", tileId, args, "Images/Cars/Bugatti_Veyron_150.png", "Assets/SmalLogo.png");

            _pinManager.UpdateSecondaryTile(tileId);
        }

        private async void PinTileWithParameters()
        {
            var tileId = BuildPinId(SecondaryTileType.WithParameters);

            if (_pinManager.IsPinned(tileId))
            {
                await _pinManager.UnPin(tileId);
            }

            var args = "SecondaryTilePage=Arg1|Arg2";
            
            await _pinManager.Pin("W/ Parameters", "Parameters Desc", tileId, args, "Images/Cars/Bugatti_Veyron_150.png", "Assets/SmalLogo.png");
        }

        private async void PinSimpleTile()
        {
            var tileId = BuildPinId(SecondaryTileType.Simple);
            
            if (_pinManager.IsPinned(tileId))
            {
                await _pinManager.UnPin(tileId);
            }

            // NOTE - have this w/ NO args and show what happens

            await _pinManager.Pin("Simple", "Simple Desc", tileId, "none", "Images/Cars/Bugatti_Veyron_150.png", "Assets/SmalLogo.png");
        }

        public void SetPinArguents(string[] arguments)
        {
            if ( arguments == null ){return;}
            ShowPageArguments = true;

            Arg1 = arguments[0];

            if ( arguments.Length > 1 )
            {
                Arg2 = arguments[1];    
            }
            
        }
    }
}