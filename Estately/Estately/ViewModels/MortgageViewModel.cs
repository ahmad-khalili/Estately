using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Estately.Views;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Estately.ViewModels
{
    public class MortgageViewModel
    {
        public string HousePrice { get; set; }
        
        public string DownPayment { get; set; }

        public string Years { get; set; }

        public string InterestRate { get; set; }

        public Command CalculateMortgage { get; set; }

        public MortgageViewModel()
        {
            CalculateMortgage = new Command(async () => await Calculate());
        }

        public async Task Calculate()
        {
            if (string.IsNullOrEmpty(HousePrice))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Property value is empty!", "Ok");
            }
            else if (string.IsNullOrEmpty(Years))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please choose the length of loan!", "Ok");
            }
            else if (string.IsNullOrEmpty(DownPayment))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Down payment is empty!", "Ok");
            }
            else if (string.IsNullOrEmpty(InterestRate))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please choose the interest rate!", "Ok");
            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new MortgageResult(HousePrice, Years, DownPayment, "5"));
            }
        }

    }

    
}
