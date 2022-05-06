using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Estately.Models;
using Estately.Services;
using MvvmHelpers;
using System.Linq;
using Estately.Views;


namespace Estately.ViewModels
{
    public class FilterViewModel : BaseViewModel
    {
        private readonly FirebaseDB services;

        public float MaxPrice { get; set; }
        public float StartSize {get; set;}
        public float EndSize {get; set;}
        public string Location { get; set; }
        public string Type { get; set; }
        public Command FilterCommand { get; set; }
        private List<Listing> _filteredlistings;
        public List<Listing> FilteredListings
        {
            get { return _filteredlistings; }
            set { _filteredlistings = value;
                OnPropertyChanged();
            }
        }

        public FilterViewModel()
        {
            services = new FirebaseDB();
            FilterCommand = new Command(() => FilterListings(MaxPrice, StartSize, EndSize, Location, Type));
        }

        public async void FilterListings(float maxPrice, float startSize, float endSize, string location, string type)
        {
            List<Listing> listingstoFilter = new List<Listing>();
            if (location == null)
            {
                listingstoFilter = (await services.GetListings())
                .Where(listing => listing.Price <= maxPrice && listing.Size > startSize && listing.Size < endSize
                && listing.Type.Equals(type))
                .ToList();
            }
            else if (type == null)
            {
                listingstoFilter = (await services.GetListings())
                .Where(listing => listing.Price <= maxPrice && listing.Size > startSize && listing.Size < endSize
                && listing.Location.Equals(location))
                .ToList();
            }
            else if (type == null && location == null)
            {
                listingstoFilter = (await services.GetListings())
                .Where(listing => listing.Price <= maxPrice && listing.Size > startSize && listing.Size < endSize)
                .ToList();
            }
            else
            {
                listingstoFilter = (await services.GetListings())
                .Where(listing => listing.Price <= maxPrice && listing.Size > startSize && listing.Size < endSize
                && listing.Type.Equals(type) && listing.Location.Equals(location))
                .ToList();
            }

            FilteredListings = listingstoFilter;

            await App.Current.MainPage.Navigation.PushAsync(new FilterResultPage(FilteredListings));
        }
    }
}
