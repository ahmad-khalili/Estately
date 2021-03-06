using System;
using System.Collections.Generic;
using System.Text;
using Estately.Services;
using Estately.Models;
using System.Collections.ObjectModel;
using MvvmHelpers;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Estately.Views;
using System.Linq;

namespace Estately.ViewModels
{
    public class MarketplaceViewModel : BaseViewModel
    {
        readonly FirebaseDB services;

        private string _title;
        public new string Title
        { 
            get {
                return _title;
            } 
            set {
                _title = value;
                OnPropertyChanged();
                SearchListings(Title);
            } 
        }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        private List<Listing> _featuredList;
        private List<Listing> _nearbyList;
        private Color _salecolor;
        public Color SaleColor
        {
            get
            {
                return _salecolor;
            }
            set
            {
                _salecolor = value;
                OnPropertyChanged();
            }
        }
        private Color _rentcolor;
        public Color RentColor
        {
            get
            {
                return _rentcolor;
            }
            set
            {
                _rentcolor = value;
                OnPropertyChanged();
            }
        }
        private Color _allcolor;
        public Color AllColor
        {
            get
            {
                return _allcolor;
            }
            set
            {
                _allcolor = value;
                OnPropertyChanged();
            }
        }
        public List<Listing> FeaturedList
        {
            get {
                return _featuredList;
            }
            set { _featuredList = value;
                OnPropertyChanged();
            }
        }
        public List<Listing> NearbyList
        {
            get
            {
                return _nearbyList;
            }
            set
            {
                _nearbyList = value;
                OnPropertyChanged();
            }
        }
        public Command AddButtonCommand {get; set; }
        public Command AllCommand { get; set; }
        public Command ForSaleCommand { get; set; }
        public Command ForRentCommand { get; set; }
        public Command FilterButtonCommand { get; set; }
        public Command SearchCommand { get; set; }

        public MarketplaceViewModel()
        {
            services = new FirebaseDB();
            GetListings();
            AllCommand = new Command(() => GetListings());
            ForSaleCommand = new Command(() => GetSaleListings());
            ForRentCommand = new Command(() => GetRentListings());
            FilterButtonCommand = new Command(() => FilterButtonClicked());
            AddButtonCommand = new Command(() => AddButtonClicked());
            SearchCommand = new Command(() => SearchListings(Title));
        }

        public async void GetListings()
        {
            AllColor = Color.FromHex("#2874a6");
            SaleColor = Color.FromHex("#61a2d8");
            RentColor = Color.FromHex("#61a2d8");
            var featuredListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("Yes")).ToList();
            var nearbyListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("No")).ToList();

            FeaturedList = featuredListings;
            NearbyList = nearbyListings;

        }

        public async void GetRentListings()
        {
            AllColor = Color.FromHex("#61a2d8");
            SaleColor = Color.FromHex("#61a2d8");
            RentColor = Color.FromHex("#2874a6");
            var featuredListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("Yes") && listing.Type.Equals("Rent")).ToList();
            var nearbyListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("No") && listing.Type.Equals("Rent")).ToList();

            FeaturedList = featuredListings;
            NearbyList = nearbyListings;
        }

        public async void GetSaleListings()
        {
            AllColor = Color.FromHex("#61a2d8");
            SaleColor = Color.FromHex("#2874a6");
            RentColor = Color.FromHex("#61a2d8");
            var featuredListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("Yes") && listing.Type.Equals("Sale")).ToList();
            var nearbyListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("No") && listing.Type.Equals("Sale")).ToList();

            FeaturedList = featuredListings;
            NearbyList = nearbyListings;
        }

        public async Task<List<Listing>> GetItemListing(string title)
        {
            var listingToGet = (await services.GetListings()).Where(listing => listing.Title.Equals(title)).ToList();
            return listingToGet;
        }

        public void AddButtonClicked()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewListingPage());
        }

        public void FilterButtonClicked()
        {
            App.Current.MainPage.Navigation.PushAsync(new FilterPage());
        }

        public void SearchListings(string title)
        {
            FeaturedList = FeaturedList
                .Where(listing => listing.Title.Contains(title, System.StringComparison.CurrentCultureIgnoreCase) && listing.Featured.Equals("Yes"))
                .ToList();

            NearbyList = NearbyList
                .Where(listing => listing.Title.Contains(title, System.StringComparison.CurrentCultureIgnoreCase) && listing.Featured.Equals("No"))
                .ToList();
        }
    }
}
