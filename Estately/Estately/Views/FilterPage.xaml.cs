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
        public FilterPage()
        {
            InitializeComponent();

            TypePicker.Items.Add("Residential");
            TypePicker.Items.Add("Commercial");
            TypePicker.Items.Add("Industrial");
            TypePicker.Items.Add("Raw Land");
            TypePicker.Items.Add("Special Use");

            PriceSlider.DragStarted += RangeSliderOnDragStarted;
            PriceSlider.DragCompleted += RangeSliderOnDragCompleted;
            PriceSlider.LowerValueChanged += RangeSliderOnLowerValueChanged;
            PriceSlider.UpperValueChanged += RangeSliderOnUpperValueChanged;
            PriceSlider.FormatLabel = currencyFormat;

            SizeSlider.DragStarted += RangeSliderOnDragStarted;
            SizeSlider.DragCompleted += RangeSliderOnDragCompleted;
            SizeSlider.LowerValueChanged += RangeSliderOnLowerValueChanged;
            SizeSlider.UpperValueChanged += RangeSliderOnUpperValueChanged;
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

        private void RangeSliderOnUpperValueChanged(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine("RangeSliderOnUpperValueChanged");
        }

        private void RangeSliderOnLowerValueChanged(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine("RangeSliderOnLowerValueChanged");
        }

        private void RangeSliderOnDragCompleted(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine("RangeSliderOnDragCompleted");
        }

        private void RangeSliderOnDragStarted(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine("RangeSliderOnDragStarted");
        }

        private async void FilterButtonClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new FilterResultPage(PriceSlider.LowerValue, PriceSlider.UpperValue, SizeSlider.LowerValue, SizeSlider.UpperValue, LocationEntry.Text));
        }
    }
}