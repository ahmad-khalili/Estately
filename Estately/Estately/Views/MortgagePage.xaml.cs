using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Estately.ViewModels;

namespace Estately.Views
{
    public partial class MortgagePage : ContentPage
    {
        public MortgagePage()
        {
            InitializeComponent();
        }

        void InterestRate_Slider(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1);
            InterestRateSlider.Value = newStep * 1;

            InterestRatePercent.Text = InterestRateSlider.Value.ToString();

            InterestRatePercent.TranslateTo(InterestRateSlider.Value * ((InterestRateSlider.Width - 40) / InterestRateSlider.Maximum), 0, 100);
        }

        private async void CalculateMortgage(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Value.Text) || string.IsNullOrEmpty(payment.Text))
            {
                await DisplayAlert("Data error!", "Please fill input again", "Ok");
                return;
            } 
            if (Convert.ToDouble(payment.Text) > Convert.ToDouble( Value.Text))
            {
                await DisplayAlert("Data error!", "down payment cannot be greater than house price", "Ok");
                return;
            }

            string HousePrice = Value.Text;

            string LoanLength = (string)picker.SelectedItem;

            string DownPayment = payment.Text;

            string InterestRate = InterestRatePercent.Text;

            await Navigation.PushAsync(new MortgageResult(HousePrice, LoanLength, DownPayment, InterestRate));

        }
    }
}
