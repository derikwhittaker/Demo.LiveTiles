using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.LiveTiles.DataModel;
using GalaSoft.MvvmLight;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace Demo.LiveTiles.ViewModel
{
    public class ToastNotificationsViewModel : ViewModelBase
    {
        private ObservableCollection<ToastNotificationOption> _toastNotificationOptions;
        private ToastNotificationOption _selectedToastNotifictioneOption;

        public ToastNotificationsViewModel()
        {
            ToastNotificationOptions = new ObservableCollection<ToastNotificationOption>(new List<ToastNotificationOption>()
                                                                                           {
                                                                                               new ToastNotificationOption{Name = "Is Feature Enabled?", 
                                                                                                   ToastNotificationType = ToastNotificationType.IsFeatureEnabled,
                                                                                                   ImagePath = @"../Images/ToastNotificationBackground.png"},

                                                                                                new ToastNotificationOption{Name = "Send Quick Toast", 
                                                                                                   ToastNotificationType = ToastNotificationType.SendTextToast,
                                                                                                   ImagePath = @"../Images/ToastNotificationBackground.png"},

                                                                                                new ToastNotificationOption{Name = "Send Future Toast", 
                                                                                                   ToastNotificationType = ToastNotificationType.SendFutureToast,
                                                                                                   ImagePath = @"../Images/ToastNotificationBackground.png"},

                                                                                                   
                                                                                                new ToastNotificationOption{Name = "Send Image Toast", 
                                                                                                   ToastNotificationType = ToastNotificationType.SendImageToast,
                                                                                                   ImagePath = @"../Images/ToastNotificationBackground.png"},
                                                                                           });
        }

        public ObservableCollection<ToastNotificationOption> ToastNotificationOptions
        {
            get { return _toastNotificationOptions; }
            set
            {
                _toastNotificationOptions = value;
                RaisePropertyChanged(() => ToastNotificationOptions);
            }
        }

        public ToastNotificationOption SelectedToastNotifictioneOption
        {
            get { return _selectedToastNotifictioneOption; }
            set
            {
                _selectedToastNotifictioneOption = value;

                RaisePropertyChanged(() => SelectedToastNotifictioneOption);

                HandleToastNotification();
            }
        }

        private void HandleToastNotification()
        {
            switch (SelectedToastNotifictioneOption.ToastNotificationType)
            {
                case ToastNotificationType.IsFeatureEnabled:
                    IsToastFeatureEnabled();
                    break;

                case ToastNotificationType.SendTextToast:
                    SendTextToast();
                    break;

                case ToastNotificationType.SendFutureToast:
                    SendFutureToast();
                    break;

                case ToastNotificationType.SendImageToast:
                    SendImageToast();
                    break;
            }
        }


        private async void IsToastFeatureEnabled()
        {

        }

        private void SendTextToast()
        {
            
        }

        private void SendFutureToast()
        {

        }


        private void SendImageToast()
        {
   
        }

    }
}