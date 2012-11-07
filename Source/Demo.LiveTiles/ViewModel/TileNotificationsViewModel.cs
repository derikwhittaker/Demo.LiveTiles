using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.LiveTiles.DataModel;
using GalaSoft.MvvmLight;

namespace Demo.LiveTiles.ViewModel
{
    public class TileNotificationsViewModel : ViewModelBase
    {
        private ObservableCollection<TileNotificationOption> _tileNotificationOptions;
        private TileNotificationOption _selectedTileNotifictioneOption;

        public TileNotificationsViewModel()
        {
            TileNotificationOptions = new ObservableCollection<TileNotificationOption>(new List<TileNotificationOption>()
                                                                                           {
                                                                                               new TileNotificationOption{Name = "Queue Single", 
                                                                                                   TileNotificationType = TileNotificationType.QueueSingleFuture,
                                                                                                   ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                                   new TileNotificationOption{Name = "Queue Many", 
                                                                                                   TileNotificationType = TileNotificationType.QueueManyFuture,
                                                                                                   ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                               new TileNotificationOption{Name = "Clear Single ", 
                                                                                                   TileNotificationType = TileNotificationType.ClearSingleQueue,
                                                                                                   ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                               new TileNotificationOption{Name = "Clear All Future", 
                                                                                                   TileNotificationType = TileNotificationType.ClearFutureQueue,
                                                                                                   ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                           });
        }

        public ObservableCollection<TileNotificationOption> TileNotificationOptions
        {
            get { return _tileNotificationOptions; }
            set
            {
                _tileNotificationOptions = value;
                RaisePropertyChanged(() => TileNotificationOptions);
            }
        }

        public TileNotificationOption SelectedTileNotifictioneOption
        {
            get { return _selectedTileNotifictioneOption; }
            set
            {
                _selectedTileNotifictioneOption = value;

                RaisePropertyChanged(() => SelectedTileNotifictioneOption);
            }
        }
    }
}
