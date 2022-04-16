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
            BindingContext = new MortgageViewModel();

            YearsPicker.Items.Add("5");
            YearsPicker.Items.Add("15");
            YearsPicker.Items.Add("30");
            YearsPicker.Items.Add("40");
        }

        void InterestRate_Slider(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1);
            InterestRateSlider.Value = newStep * 1;

            InterestRatePercent.Text = InterestRateSlider.Value.ToString();

            InterestRatePercent.TranslateTo(InterestRateSlider.Value * ((InterestRateSlider.Width - 40) / InterestRateSlider.Maximum), 0, 100);
        }

    }
}
