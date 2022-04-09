using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Estately.Models;
using Estately.Services;
using MvvmHelpers;


namespace Estately.ViewModels
{
    public class FilterViewModel
    {
        private FirebaseDB services;

        public FilterViewModel()
        {
            services = new FirebaseDB();
        }

        public async Task<List<Listing>> filterListings(float startPrice, float endPrice, float startSize, float endSize, string location, string type)
        {
            return await services.FilterListing(startPrice, endPrice, startSize, endSize, location, type);
        }
    }
}
