namespace Demo.LiveTiles.DataModel
{
    public class SecondaryTileOption
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public SecondaryTileType SecondaryTileType { get; set; }

    }

    public enum SecondaryTileType
    {
        Unknown,
        Simple,
        WithParameters
    }
}