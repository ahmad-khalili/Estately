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
            await App.Current.MainPage.Navigation.PushAsync(new MortgageResult(HousePrice, Years, DownPayment, "5"));
        }

    }

    
}
