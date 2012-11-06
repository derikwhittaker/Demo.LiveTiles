using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.LiveTiles.DataModel;
using GalaSoft.MvvmLight;

namespace Demo.LiveTiles.ViewModel
{
    public class SecondaryTilesViewModel : ViewModelBase
    {
        private ObservableCollection<SecondaryTileOption> _secondaryTileOptions;
        private SecondaryTileOption _selectedSecondaryTileOption;

        public SecondaryTilesViewModel()
        {
            SecondaryTileOptions = new ObservableCollection<SecondaryTileOption>(new List<SecondaryTileOption>
                                                                             {
                                                                                 new SecondaryTileOption{Name = "Simple Solution", 
                                                                                     ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                 new SecondaryTileOption{Name = "With Parameters", 
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

            }
        }
    }
}