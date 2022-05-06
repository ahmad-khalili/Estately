using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Windows.Input;
using Estately.Views;


namespace Estately.ViewModels
{
    public class RenovationViewModel
    {
        public string PropartySize { get; set; }

        public string PropartyValue { get; set; }

        public string Room1 { get; set; }
        public string Room2 { get; set; }
        public string Room3 { get; set; }

  
        public async Task Renovation()
        {

            if (string.IsNullOrEmpty(PropartySize))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "PropartySize is Empty!", "Ok");
            }
            else if (string.IsNullOrEmpty(PropartyValue))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "PropartyValue is Empty!", "Ok");

            }
            else if (string.IsNullOrEmpty(Room1))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Room1 is Empty!", "Ok");

            }
            else if (string.IsNullOrEmpty(Room2))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Room2 is Empty!", "Ok");

            }
            else if (string.IsNullOrEmpty(Room3))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Room3 is Empty!", "Ok");


            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new RenovationResults(PropartySize, Room1, Room2, Room3));

            }
        }

        public Command CalculateRenovation { get; set; }
        public RenovationViewModel()
        {
            CalculateRenovation = new Command(async () => await Renovation());
        }


    }
}
