using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Estately.Views
{
    public partial class RennovationPage : ContentPage
    {
        public RennovationPage()
        {
            InitializeComponent();
        }
        
        private async void Button_clicked(Object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RennovationPage2());
        }

    }
}
