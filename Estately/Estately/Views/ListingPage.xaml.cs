using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Estately.Models;
using Estately.ViewModels;

namespace Estately.Views
{
    public partial class ListingPage : ContentPage
    {
        string title { get; set; }
        MarketplaceViewModel viewModel = new MarketplaceViewModel();
        public ListingPage(string title)
        {
            InitializeComponent();
            this.title = title;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            page.Title = title;
            listingView.ItemsSource = await viewModel.GetItemListing(title);
        }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync("//MarketplacePage");
            return base.OnBackButtonPressed();
        }
    }
}