using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Estately.ViewModels;
using Estately.Models;

namespace Estately.Views
{
    public partial class FilterResultPage : ContentPage
    {
        public FilterResultPage(List<Listing> listings)
        {
            InitializeComponent();
            filteredListings.ItemsSource = listings;
        }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync("//MarketplacePage");
            return base.OnBackButtonPressed();
        }
    }
}