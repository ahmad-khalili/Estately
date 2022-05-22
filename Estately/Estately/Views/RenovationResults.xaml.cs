using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Estately.Views
{
    public partial class RenovationResults : ContentPage
    {
        public RenovationResults(string propertyValue, string propartySize, double room1Value, double room2Value, double room3Value, 
            string room1, string room2, string room3)
        {
            InitializeComponent();

            PropartySize.Text = propartySize + " m²";
            Room1Label.Text = room1;
            Room2Label.Text = room2;
            Room3Label.Text = room3;
            Room1Value.Text = room1Value.ToString() + " m²";
            Room2Value.Text = room2Value.ToString() + " m²";
            Room3Value.Text = room3Value.ToString() + " m²";


            PropartyValue.Text = propertyValue + " $";


            double equation1 = (room1Value * 10);
            double equation2 = (room2Value* 10);
            double equation3 = (room3Value * 10);
            double equation4 = equation1 + equation2 + equation3;


            double renovationEquation = equation4;

            Result.Text = renovationEquation.ToString() + " $";
        }
    }
}


