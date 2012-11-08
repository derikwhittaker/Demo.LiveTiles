namespace Demo.LiveTiles.DataModel
{
    public class ToastNotificationOption
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public ToastNotificationType ToastNotificationType { get; set; }

    }

    public enum ToastNotificationType
    {
        Unknown,
        IsFeatureEnabled,
        SendTextToast,
        SendImageToast,
        SendFutureToast
    }
}