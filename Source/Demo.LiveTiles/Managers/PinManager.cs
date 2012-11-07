using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationsExtensions.TileContent;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;

namespace Demo.LiveTiles.Managers
{
    public interface IPinManager
    {

        bool IsPinned(string pinnedItemId);

        Task<bool> Pin(string shortName, string description, string tileId, string tileActivationArgs, string tileLogoPath, string smallTileLogoPath);
        Task<bool> UnPin(string pinnedItemId);

        void UpdateSecondaryTile(string tileIdToUpdate);
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

        public async void UpdateSecondaryTile(string tileIdToUpdate)
        {
            var allTiles = await SecondaryTile.FindAllAsync();

            foreach (var secondaryTile in allTiles)
            {
                if ( secondaryTile.TileId == tileIdToUpdate )
                {
                    var updatableSecondaryTile = TileContentFactory.CreateTileSquarePeekImageAndText01();
                    var tileUpdater = TileUpdateManager.CreateTileUpdaterForSecondaryTile(secondaryTile.TileId);
                    tileUpdater.Clear();

                    updatableSecondaryTile.Image.Src = @"../Images/Cars/Bugatti_Veyron_150.png";
                    updatableSecondaryTile.TextHeading.Text = "Updated Text";
                    updatableSecondaryTile.TextBody1.Text = "text 1";
                    updatableSecondaryTile.TextBody2.Text = "text 2";
                    updatableSecondaryTile.TextBody3.Text = "text 3";

                    var tileNotification = updatableSecondaryTile.CreateNotification();
                    tileUpdater.Update(tileNotification);
                    break;
                }
            }
        }
    }
}
