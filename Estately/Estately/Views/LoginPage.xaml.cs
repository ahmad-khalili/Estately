using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Estately.Views;

namespace Estately.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync("//MoreTabsPage");
            return base.OnBackButtonPressed();
        }
    }
}