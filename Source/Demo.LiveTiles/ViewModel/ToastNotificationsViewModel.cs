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
            var notifier = ToastNotificationManager.CreateToastNotifier();

            // Make sure notifications are enabled
            if (notifier.Setting != NotificationSetting.Enabled)
            {
                var dialog = new MessageDialog("Notifications are currently disabled");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Notifications are currently enabled");
                await dialog.ShowAsync();
            }
        }

        private void SendTextToast()
        {
            
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            
            var element = template.GetElementsByTagName("text")[0];
            element.AppendChild(template.CreateTextNode("Line 1 goes here"));

            var toast = new ToastNotification(template);
            notifier.Show(toast);

        }

        private void SendFutureToast()
        {

            var notifier = ToastNotificationManager.CreateToastNotifier();
            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            var element = template.GetElementsByTagName("text")[0];
            element.AppendChild(template.CreateTextNode("I am from the future"));

            // Schedule the toast to appear 10 seconds from now
            var date = DateTimeOffset.Now.AddSeconds(10);
            var scheduledToast = new ScheduledToastNotification(template, date);
            notifier.AddToSchedule(scheduledToast);
        }


        private void SendImageToast()
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);

            var element = template.GetElementsByTagName("text")[0];
            element.AppendChild(template.CreateTextNode("Image Line Goes Here"));

            var images = template.GetElementsByTagName("image");
            ((XmlElement)images[0]).SetAttribute("src", "Images/GreenToastSquare.png");
            
            var toast = new ToastNotification(template);
            notifier.Show(toast);
        }

    }
}