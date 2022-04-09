using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Estately.ViewModels;
using System.Reflection;

namespace Estately.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RennovationPage : ContentPage
    {
        public RennovationPage()
        {
            InitializeComponent();
        }
        private async void CalculateRonovation(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(entry2.Text) || string.IsNullOrEmpty(entry3.Text))
            {
                await DisplayAlert("Data error!", "Please fill input again", "Ok");
                return;
            }


            string PropartySize = entry2.Text;

            string PropartyValue = entry3.Text;

            string Room1 = room1.Text;
            string Room2 = room2.Text;
            string Room3 = room3.Text;


            await Navigation.PushAsync(new RenovationResults(PropartySize, Room1,Room2,Room3));

        }

    }
}



