using Demo.LiveTiles.ViewModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Demo.LiveTiles.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class TileNotificationsPage : Demo.LiveTiles.Common.LayoutAwarePage
    {
        public TileNotificationsPage()
        {
            this.InitializeComponent();

            DataContext = new TileNotificationsViewModel();
        }

    }
}
