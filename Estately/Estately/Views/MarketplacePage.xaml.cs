using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

using Estately;
using Estately.ViewModels;
using Estately.Models;

namespace Estately.Views
{
    public partial class MarketplacePage : ContentPage
    {
        public MarketplacePage()
        {
            InitializeComponent();
            BindingContext = new MarketplaceViewModel();
        }
    }
}