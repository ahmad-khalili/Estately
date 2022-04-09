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
    public partial class NewListingPage : ContentPage
    {
        public NewListingPage()
        {
            InitializeComponent();
            BindingContext = new MarketplaceViewModel();
            TypePicker.Items.Add("Sale");
            TypePicker.Items.Add("Rent");
        }
    }
}
