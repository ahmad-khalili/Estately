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
            if (label.Text == "Login")
            {
                Shell.Current.Navigation.PushAsync(new LoginPage());
            }
            else if (label.Text == "Registration")
            {
                Shell.Current.Navigation.PushAsync(new RegistrationPage());
            }
        }
    }
}