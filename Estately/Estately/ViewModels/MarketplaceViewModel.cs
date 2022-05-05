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
        public Command AddListingCommand { get; set; }
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
            AddListingCommand = new Command(async () => await AddListing());
            AllCommand = new Command(() => GetListings());
            ForSaleCommand = new Command(() => GetSaleListings());
            ForRentCommand = new Command(() => GetRentListings());
            FilterButtonCommand = new Command(() => FilterButtonClicked());
            AddButtonCommand = new Command(() => AddButtonClicked());
            SearchCommand = new Command(() => SearchListings(Title));
        }

        public async void GetListings()
        {
            var featuredListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("Yes")).ToList();
            var nearbyListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("No")).ToList();

            FeaturedList = featuredListings;
            NearbyList = nearbyListings;

        }

        public async void GetRentListings()
        {
            var featuredListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("Yes") && listing.Type.Equals("Rent")).ToList();
            var nearbyListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("No") && listing.Type.Equals("Rent")).ToList();

            FeaturedList = featuredListings;
            NearbyList = nearbyListings;
        }

        public async void GetSaleListings()
        {
            var featuredListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("Yes") && listing.Type.Equals("Sale")).ToList();
            var nearbyListings = (await services.GetListings())
                .Where(listing => listing.Featured.Equals("No") && listing.Type.Equals("Sale")).ToList();

            FeaturedList = featuredListings;
            NearbyList = nearbyListings;
        }

        public async Task AddListing()
        {
            if (string.IsNullOrEmpty(Title))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Title is Empty!", "Ok");
            }
            else if (string.IsNullOrEmpty(Description))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Description is Empty!", "Ok");

            }
            else if (string.IsNullOrEmpty(Type))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Type is Empty!", "Ok");

            }
            else if (string.IsNullOrEmpty(Location))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Location is Empty!", "Ok");

            }
            else
            {
                try
                {
                    var listing = new Listing { Title = Title, Description = Description, Price = Price, Type = Type, Location = Location, Featured = "No" };
                    await services.AddListing(listing);
                    await App.Current.MainPage.DisplayAlert("Success", Title + " Added", "Ok");
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Incorrect or empty inputs", "Ok");
                }
            }

        }

        public async Task<List<Listing>> GetItemListing(string title)
        {
            return await services.GetListing(title);
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
