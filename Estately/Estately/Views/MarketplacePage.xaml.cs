using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Estately.ViewModels;

namespace Estately.Views
{
    public partial class MarketplacePage : ContentPage
    {
        string type { get; set; }


        MarketplaceViewModel marketplaceViewModel = new MarketplaceViewModel();

        public MarketplacePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var featuredListings = await marketplaceViewModel.FeaturedListings(type);
            var nearbyListings = await marketplaceViewModel.NearbyListings(type);

            featuredList.ItemsSource = featuredListings;
            nearbyList.ItemsSource = nearbyListings;
            type = null;

        }

        public void AllButtonClicked(object sender, EventArgs eventArgs)
        {
            OnAppearing();
        }

        public void ForSaleButtonClicked(object sender, EventArgs eventArgs)
        {
            type = "Sale";
            OnAppearing();
        }

        public void ForRentButtonClicked(object sender, EventArgs eventArgs)
        {
            type = "Rent";
            OnAppearing();
        }
        public void FilterButtonClicked(object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new FilterPage());
        }
    }
}