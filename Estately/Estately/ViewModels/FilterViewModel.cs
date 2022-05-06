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

        private float _maxprice;
        public float MaxPrice 
        {
            get
            {
                return _maxprice;
            }
            set
            {
                _maxprice = value;
                OnPropertyChanged();
            }
        }
        private float _startsize;
        public float StartSize
        {
            get
            {
                return _startsize;
            }
            set
            {
                _startsize = value;
                OnPropertyChanged();
            }
        }
        private float _endsize;
        public float EndSize
        {
            get
            {
                return _endsize;
            }
            set
            {
                _endsize = value;
                OnPropertyChanged();
            }
        }
        private string _location;
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }
        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }
        public Command FilterCommand { get; set; }
        public Command ClearCommand { get; set; }

        public FilterViewModel()
        {
            MaxPrice = 500000;
            StartSize = 0;
            EndSize = 100000;
            Location = null;
            Type = null;
            services = new FirebaseDB();
            FilterCommand = new Command(() => FilterListings());
            ClearCommand = new Command(() => ClearPressed());
        }

        public async void FilterListings()
        {
            List<Listing> filteredListings = new List<Listing>();
            if (Location == null && Type != null)
            {
                filteredListings = (await services.GetListings())
                .Where(listing => listing.Price <= MaxPrice && listing.Size > StartSize && listing.Size < EndSize
                && listing.Type.Equals(Type))
                .ToList();
            }
            else if (Type == null && Location != null)
            {
                filteredListings = (await services.GetListings())
                .Where(listing => listing.Price <= MaxPrice && listing.Size > StartSize && listing.Size < EndSize
                && listing.Location.Contains(Location, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            }
            else if (Type == null && Location == null)
            {
                filteredListings = (await services.GetListings())
                .Where(listing => listing.Price <= MaxPrice && listing.Size > StartSize && listing.Size < EndSize)
                .ToList();
            }
            else
            {
                filteredListings = (await services.GetListings())
                .Where(listing => listing.Price <= MaxPrice && listing.Size > StartSize && listing.Size < EndSize
                && listing.Type.Equals(Type) && listing.Location.Contains(Location, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            }

            await App.Current.MainPage.Navigation.PushAsync(new FilterResultPage(filteredListings));
        }

        public void ClearPressed()
        {
            Type = null;
            Location = null;
            MaxPrice = 500000;
            StartSize = 0;
            EndSize = 100000;
        }
    }
}
