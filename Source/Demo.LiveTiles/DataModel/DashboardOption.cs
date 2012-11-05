using System;

namespace Demo.LiveTiles.DataModel
{
    public class DashboardOption
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public Type PageType { get; set; }
    }

    public class LiveTileOption
    {
        public string Name { get; set; }
        
        public string ImagePath { get; set; }

    }
}
