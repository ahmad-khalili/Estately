using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

using Estately;
using Estately.ViewModels;
using Estately.Models;

namespace Estately.Views
{
    public partial class MarketplacePage : ContentPage
    {
        Color primary;
        readonly MarketplaceViewModel marketplaceViewModel = new MarketplaceViewModel();

        public MarketplacePage()
        {
            InitializeComponent();
            primary = AllButton.BackgroundColor;
            BindingContext = marketplaceViewModel;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AllButton.BackgroundColor = primary;
            SaleButton.BackgroundColor = Color.DarkGray;
            RentButton.BackgroundColor = Color.DarkGray;

            featuredList.ItemsSource = await marketplaceViewModel.FeaturedListings(null);
            nearbyList.ItemsSource = await marketplaceViewModel.NearbyListings(null);
        }

        public async void AllButtonClicked(object sender, EventArgs eventArgs)
        {
            AllButton.BackgroundColor = primary;
            SaleButton.BackgroundColor = Color.DarkGray;
            RentButton.BackgroundColor = Color.DarkGray;
            featuredList.ItemsSource = await marketplaceViewModel.FeaturedListings(null);
            nearbyList.ItemsSource = await marketplaceViewModel.NearbyListings(null);
        }

        public async void ForSaleButtonClicked(object sender, EventArgs eventArgs)
        {
            SaleButton.BackgroundColor= primary;
            AllButton.BackgroundColor = Color.DarkGray;
            RentButton.BackgroundColor = Color.DarkGray;
            featuredList.ItemsSource = await marketplaceViewModel.FeaturedListings("Sale");
            nearbyList.ItemsSource = await marketplaceViewModel.NearbyListings("Sale");
        }

        public async void ForRentButtonClicked(object sender, EventArgs eventArgs)
        {
            RentButton.BackgroundColor = primary;
            SaleButton.BackgroundColor = Color.DarkGray;
            AllButton.BackgroundColor = Color.DarkGray;
            featuredList.ItemsSource = await marketplaceViewModel.FeaturedListings("Rent");
            nearbyList.ItemsSource = await marketplaceViewModel.NearbyListings("Rent");
        }

        public async void AddButtonClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new NewListingPage());
        }

        public void FilterButtonClicked(object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new FilterPage());
        }
    }
}