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
        //List<Listing> favoriteListings = JsonConvert.DeserializeObject<List<Listing>>(Application.Current.Properties["FavoritesList"].ToString());
        readonly MarketplaceViewModel marketplaceViewModel = new MarketplaceViewModel();
        readonly ListingComponent listingComponent = new ListingComponent();

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
            //checkFavorites();
        }

        public async void AllButtonClicked(object sender, EventArgs eventArgs)
        {
            AllButton.BackgroundColor = primary;
            SaleButton.BackgroundColor = Color.DarkGray;
            RentButton.BackgroundColor = Color.DarkGray;
            featuredList.ItemsSource = await marketplaceViewModel.FeaturedListings(null);
            nearbyList.ItemsSource = await marketplaceViewModel.NearbyListings(null);
            //checkFavorites();
        }

        public async void ForSaleButtonClicked(object sender, EventArgs eventArgs)
        {
            SaleButton.BackgroundColor= primary;
            AllButton.BackgroundColor = Color.DarkGray;
            RentButton.BackgroundColor = Color.DarkGray;
            featuredList.ItemsSource = await marketplaceViewModel.FeaturedListings("Sale");
            nearbyList.ItemsSource = await marketplaceViewModel.NearbyListings("Sale");
            //checkFavorites();
        }

        public async void ForRentButtonClicked(object sender, EventArgs eventArgs)
        {
            RentButton.BackgroundColor = primary;
            SaleButton.BackgroundColor = Color.DarkGray;
            AllButton.BackgroundColor = Color.DarkGray;
            featuredList.ItemsSource = await marketplaceViewModel.FeaturedListings("Rent");
            nearbyList.ItemsSource = await marketplaceViewModel.NearbyListings("Rent");
            //checkFavorites();
        }

        public async void AddButtonClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new NewListingPage());
        }

        public void FilterButtonClicked(object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new FilterPage());
        }

        /*private void checkFavorites()
        {
            if (favoriteListings != null && featuredList.ItemsSource != null && nearbyList.ItemsSource != null)
            {
                foreach (var listing in featuredList.ItemsSource)
                {
                    if (favoriteListings.Contains(listing))
                    {
                        listingComponent.MarkListing();
                    }
                }

                foreach (var listing in nearbyList.ItemsSource)
                {
                    if (favoriteListings.Contains(listing))
                    {
                        listingComponent.MarkListing();
                    }
                }
            }
        }*/
    }
}