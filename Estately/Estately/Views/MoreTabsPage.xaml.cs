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

        public void ItemClicked(object sender, EventArgs eventArgs)
        {
            var label = sender as Label;
            if (label.Text == "Renovation Calculator")
            {
                Shell.Current.Navigation.PushAsync(new RennovationPage());
            }
            if (label.Text == "Profile Page")
            {
                Shell.Current.Navigation.PushAsync(new ProfilePage());
            }
            if (label.Text == "Mortgage Calculator")
            {
                Shell.Current.Navigation.PushAsync(new MortgagePage());
            }
        }
    }
}