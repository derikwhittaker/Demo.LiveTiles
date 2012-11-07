using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;

namespace Demo.LiveTiles.Managers
{
    public interface IPinManager
    {

        bool IsPinned(string pinnedItemId);

        Task<bool> Pin(string shortName, string description, string tileId, string tileActivationArgs, string tileLogoPath, string smallTileLogoPath);
        Task<bool> UnPin(string pinnedItemId);
    }

    public class PinManager : IPinManager
    {
        public bool IsPinned(string pinnedItemId)
        {
            var result = SecondaryTile.Exists(pinnedItemId);
            return result;
        }

        public async Task<bool> Pin(string shortName, string description, string tileId, string tileActivationArgs, string tileLogoPath, string smallTileLogoPath)
        {
            var logo = new Uri(string.Format("ms-appx:///{0}", tileLogoPath));
            var smallLogo = new Uri(string.Format("ms-appx:///{0}", smallTileLogoPath));

            var tile = new SecondaryTile(tileId, shortName, description, tileActivationArgs, TileOptions.ShowNameOnLogo, logo);

            tile.ForegroundText = ForegroundText.Light;
            tile.SmallLogo = smallLogo;

            var result = await tile.RequestCreateAsync();

            return result;
        }

        public async Task<bool> UnPin(string pinnedItemId)
        {
            if (IsPinned(pinnedItemId))
            {
                var tile = new SecondaryTile(pinnedItemId);
                var result = await tile.RequestDeleteAsync();

                return result;
            }

            return false;
        }
    }
}
