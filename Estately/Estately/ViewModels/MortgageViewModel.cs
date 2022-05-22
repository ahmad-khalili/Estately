using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Estately.Views;
using System.Windows.Input;
using System.Threading.Tasks;
using MvvmHelpers;

namespace Estately.ViewModels
{
    public class MortgageViewModel : BaseViewModel
    {
        public string HousePrice { get; set; }
        
        public string DownPayment { get; set; }

        public string Years { get; set; }

        private double _interestrate;
        public double InterestRate
        {
            get
            {
                return _interestrate;
            }
            set
            {
                _interestrate = value;
                OnPropertyChanged();
            }
        }

        public Command CalculateMortgage { get; set; }

        public MortgageViewModel()
        {
            InterestRate = 1;
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
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new MortgageResult(HousePrice, Years, DownPayment, InterestRate));
            }
        }

    }

    
}
