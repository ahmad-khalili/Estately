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
            BindingContext = new FilterViewModel();

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
    }
}