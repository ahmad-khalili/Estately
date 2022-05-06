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

        public string Room1Name { get; set; }
        public string Room2Name { get; set; }
        public string Room3Name { get; set; }
        public string Room1Value { get; set; }
        public string Room2Value { get; set; }
        public string Room3Value { get; set; }


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
            else if (string.IsNullOrEmpty(Room1Name))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Room #1 is Empty!", "Ok");

            }
            else if (string.IsNullOrEmpty(Room2Name))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Room #2 is Empty!", "Ok");

            }
            else if (string.IsNullOrEmpty(Room3Name))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Room #3 is Empty!", "Ok");


            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new RenovationResults(PropartyValue, PropartySize, double.Parse(Room1Value),
                    double.Parse(Room2Value), double.Parse(Room3Value), Room1Name, Room2Name, Room3Name));

            }
        }

        public Command CalculateRenovation { get; set; }
        public RenovationViewModel()
        {
            CalculateRenovation = new Command(async () => await Renovation());
        }


    }
}
