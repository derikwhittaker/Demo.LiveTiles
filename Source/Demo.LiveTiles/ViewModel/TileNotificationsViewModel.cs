using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                                                                                                   ImagePath = @"../Images/LiveTileBackground.png"},
                                                                                                   new TileNotificationOption{Name = "Queue To Expire", 
                                                                                                   TileNotificationType = TileNotificationType.QueueTileToExpire,
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

                case TileNotificationType.ClearSingleQueue:
                break;

                case TileNotificationType.ClearFutureQueue:
                break;
            }
        }

        private void QueueNotification()
        {
            var applicationTile = TileContentFactory.CreateTileWidePeekImage02();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            // clear the existing tile info
            tileUpdater.Clear();

            applicationTile.TextHeading.Text = "Future Top Scores";
            applicationTile.TextBody1.Text = "Future Player 1 - 100";
            applicationTile.TextBody2.Text = "Future Player 1 - 92";
            applicationTile.TextBody3.Text = "Future Player 1 - 90";
            applicationTile.TextBody4.Text = "Future Player 1 - 85";

            applicationTile.RequireSquareContent = false;
            applicationTile.Image.Src = @"../Images/Tiles/TileWideImageCollection.png";

            var futureTile = new ScheduledTileNotification(applicationTile.GetXml(), DateTime.Now.AddSeconds(10));

            tileUpdater.AddToSchedule(futureTile);
        }

        private void QueueExpiringNotification()
        {
            var applicationTile = TileContentFactory.CreateTileWideText01();
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication(CoreApplication.Id);

            // clear the existing tile info
            tileUpdater.Clear();

            applicationTile.TextHeading.Text = "Future Top Scores";
            applicationTile.TextBody1.Text = "Will Expire soon";

            applicationTile.RequireSquareContent = false;

            var futureTile = new ScheduledTileNotification(applicationTile.GetXml(), DateTime.Now.AddSeconds(5));

            futureTile.ExpirationTime = DateTime.Now.AddSeconds(15);

            tileUpdater.AddToSchedule(futureTile);
        }
    }
}
