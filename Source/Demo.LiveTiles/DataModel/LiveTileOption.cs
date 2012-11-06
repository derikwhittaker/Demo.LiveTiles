using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Demo.LiveTiles.DataModel
{
    public class LiveTileOption
    {
        public string Name { get; set; }
        
        public string ImagePath { get; set; }

        public LiveTileType LiveTileType { get; set; }

    }

    public class LiveTileGroup
    {
        public string Name { get; set; }

        public List<LiveTileOption> Items { get; set; }
    }

    public enum LiveTileType
    {
        Unknown,
        SquareBlock,
        SquareImageOnly,
        SquareImagePeek,
        SquareText,
        WideImage,
        WideImageAndText,
        WideImageCollection,
        WideText
    }

}