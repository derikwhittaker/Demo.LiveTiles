using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Demo.LiveTiles.DataModel
{
    public class LiveTileOption
    {
        public string Name { get; set; }
        
        public string ImagePath { get; set; }

    }

    public class LiveTileGroup
    {
        public string Name { get; set; }

        public List<LiveTileOption> Items { get; set; }
    }

}