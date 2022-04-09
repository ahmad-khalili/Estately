using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.RangeSlider.Common;
using Estately.ViewModels;

namespace Estately.Views
{
    public partial class FilterPage : ContentPage
    {
        string selectedType = null;
        public FilterPage()
        {
            InitializeComponent();

            TypePicker.Items.Add("Sale");
            TypePicker.Items.Add("Rent");

            PriceSlider.FormatLabel = currencyFormat;
            SizeSlider.FormatLabel = sizeFormat;
        }


        private string currencyFormat(Thumb thumb, float val)
        {
            var value = string.Format("{0:n}", val);
            return "$" + value;
        }
        private string sizeFormat(Thumb thumb, float val)
        {
            var value = string.Format("{0:n}", val);
            return "sq ft." + value;
        }

        public async void FilterButtonClicked(object sender, EventArgs eventArgs)
        {
            if (TypePicker.SelectedIndex > 0)
            {
                selectedType = TypePicker.Items[TypePicker.SelectedIndex];
            }

            await Navigation.PushAsync(new FilterResultPage(PriceSlider.LowerValue, PriceSlider.UpperValue, SizeSlider.LowerValue, SizeSlider.UpperValue, LocationEntry.Text, selectedType));
        }

        public void ClearButtonClicked(object sender, EventArgs eventArgs)
        {
            TypePicker.SelectedIndex = -1;
            LocationEntry.Text = null;
            PriceSlider.UpperValue = 500000;
            SizeSlider.LowerValue = 0;
            SizeSlider.UpperValue = 100000;
        } 
    }
}