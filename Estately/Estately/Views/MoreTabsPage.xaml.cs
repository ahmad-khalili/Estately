using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Estately.Views
{
    public partial class MoreTabsPage : ContentPage
    {
        public MoreTabsPage()
        {
            InitializeComponent();        
        }

        public async void ProfileTabbed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        public async void MortgageTabbed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MortgagePage());
        }
        public async void RenovationTabbed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RennovationPage());
        }
    }
}