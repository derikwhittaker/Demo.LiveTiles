namespace Demo.LiveTiles.DataModel
{
    public class TileNotificationOption
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public TileNotificationType TileNotificationType { get; set; }

    }

    public enum TileNotificationType
    {
        Unknown,
        QueueSingleFuture,
        QueueManyFuture,
        ClearFutureQueue,
        ClearSingleQueue
    }
}