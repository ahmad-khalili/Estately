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

  
        public ICommand CalculateCommand { get; set; }



        public async Task Ronovation()
        {

            if (string.IsNullOrEmpty(PropartySize))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "PropartySize is Empty!", "Ok");
            }
            else if (string.IsNullOrEmpty(PropartyValue))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "PropartyValue is Empty!", "Ok");

            }


            await App.Current.MainPage.Navigation.PushAsync(new RenovationResults(PropartySize, Room1, Room2, Room3));

        }


        public Command CalculateRonovation { get; set; }
        public RenovationViewModel()
        {
            CalculateRonovation = new Command(async () => await Ronovation());
        }


    }
}
