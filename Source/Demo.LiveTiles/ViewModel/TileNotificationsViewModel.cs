using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Demo.LiveTiles.DataModel;
using GalaSoft.MvvmLight;
using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Core;
using Windows.UI.Notifications;

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
                                                                                                   ImagePath = @"../Images/TileNotificationsBackground.png"},
                                                                                                   new TileNotificationOption{Name = "Queue To Expire", 
                                                                                                   TileNotificationType = TileNotificationType.QueueTileToExpire,
                                                                                                   ImagePath = @"../Images/TileNotificationsBackground.png"},
                                                                                               new TileNotificationOption{Name = "Query Notifications ", 
                                                                                                   TileNotificationType = TileNotificationType.QueryNotificationTiles,
                                                                                                   ImagePath = @"../Images/TileNotificationsBackground.png"},
                                                                                               new TileNotificationOption{Name = "Clear All Future", 
                                                                                                   TileNotificationType = TileNotificationType.ClearFutureQueue,
                                                                                                   ImagePath = @"../Images/TileNotificationsBackground.png"},
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

                HandleTileNotification();
            }
        }

        private void HandleTileNotification()
        {
            switch (SelectedTileNotifictioneOption.TileNotificationType)
            {
                case TileNotificationType.QueueSingleFuture:
                    QueueNotification();
                break;

                case TileNotificationType.QueueTileToExpire:
                    QueueExpiringNotification();
                break;

                case TileNotificationType.QueryNotificationTiles:
                    QueryNotificationTiles();
                break;

                case TileNotificationType.ClearFutureQueue:
                    ClearFutureQueue();
                break;
            }
        }

        private void QueueNotification()
        {

        }

        private void QueueExpiringNotification()
        {

        }
        
        private void QueryNotificationTiles()
        {
           
        }

        private void ClearFutureQueue()
        {

        }
    }
}
