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
    public partial class FilterResultPage : ContentPage
    {
        FilterViewModel viewModel = new FilterViewModel();
        float startPrice { get; set; }
        float endPrice { get; set; }
        float startSize { get; set; }
        float endSize { get; set; }
        string location { get; set; }
        public FilterResultPage(float startPrice, float endPrice, float startSize, float endSize, string location)
        {
            this.startPrice = startPrice;
            this.endPrice = endPrice;
            this.startSize = startSize;
            this.endSize = endSize;
            this.location = location;
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var filteredListings = await viewModel.filterListings(startPrice, endPrice, startSize, endSize, location);
            ListingsList.ItemsSource = filteredListings;
        }
    }
}