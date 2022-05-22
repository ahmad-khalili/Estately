using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Estately.ViewModels;
using Estately.Models;
using Newtonsoft.Json;

namespace Estately.Views
{
    public partial class ListingComponent : Grid
    {
        MarketplaceViewModel viewModel = new MarketplaceViewModel();
        public ListingComponent()
        {
            InitializeComponent();
        }

        public async void ItemClicked(object sender, EventArgs eventArgs)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ListingPage(titleLabel.Text));
        }
    }
}