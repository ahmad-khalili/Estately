using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Estately.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new RegistrationViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync("//MoreTabsPage");
            return base.OnBackButtonPressed();
        }

    }
}