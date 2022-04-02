using System;
using System.Collections.Generic;
using System.Text;
using Estately.Services;
using Estately.Models;
using System.Collections.ObjectModel;
using MvvmHelpers;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Estately.ViewModels
{
    public class MarketplaceViewModel : BaseViewModel
    {
        FirebaseDB services;
        public new string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }

        public MarketplaceViewModel()
        {
            services = new FirebaseDB();
            Listings = services.getListing();
        }
        

        private ObservableCollection<Listing> _listing = new ObservableCollection<Listing>();
        public ObservableCollection<Listing> Listings
        {
            get { return _listing; }
            set
            {
                _listing = value;
                OnPropertyChanged();
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
    
    }
}
