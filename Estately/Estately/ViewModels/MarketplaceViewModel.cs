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

namespace Estately.ViewModels
{
    public class MarketplaceViewModel
    {
        FirebaseDB services;
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public Command AddListingCommand { get; set; }
        public MarketplaceViewModel()
        {
            services = new FirebaseDB();
            AddListingCommand = new Command(async () => await AddListing());
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

        public async Task<List<Listing>> FeaturedListings(string type)
        {
            return await services.GetFeaturedProperties(type);
        }

        public async Task<List<Listing>> NearbyListings(string type)
        {
            return await services.GetNearbyProperties(type);
        }

        public async Task<List<Listing>> GetItemListing(string title)
        {
            return await services.GetListing(title);
        }
    }
}
