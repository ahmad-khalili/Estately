using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Estately.Views
{
    public partial class NewListingPage : ContentPage
    {
        public NewListingPage()
        {
            InitializeComponent();

            var picker = new Picker { Title = "Select a Listing Price Currency", TitleColor = Color.Red };
            picker.Items.Add("USD");
            picker.Items.Add("NIS");
            picker.Items.Add("EUR");

            var picker = new Picker { Title = "Select a Property Size Metric", TitleColor = Color.Red };
            picker.Items.Add("sq.ft");
            picker.Items.Add("meters squared");

            var picker = new Picker { Title = "Select a Property Type", TitleColor = Color.Red };
            picker.Items.Add("Residential");
            picker.Items.Add("Commercial");
            picker.Items.Add("Industrial");
            picker.Items.Add("Raw Land");
            picker.Items.Add("Special Use");
           
        }
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex = 0)
            {
                PriceCurrencyNameLabel.Text = picker.Items[selectedIndex];
            }
            else if (selectedIndex = 1)
            {
                PropertySizeMetricNameLabel.Text = picker.Items[selectedIndex];
            }
            else if (selectedIndex = 2)
            {
                PropertyTypeNameLabel.Text = picker.Items[selectedIndex];
            }
         
        }


    }
}
