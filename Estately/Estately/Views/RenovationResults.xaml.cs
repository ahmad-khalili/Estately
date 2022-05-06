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
        public RenovationResults(string propartySize, string room1, string room2, string room3)
        {
            InitializeComponent();

            PropartySize.Text = "Metres" + propartySize;
            Room1.Text = room1;
            Room1.Text = room2;
            Room1.Text = room2;


            double price = double.Parse(propartySize);
            double firstroom = double.Parse(room1);
            double secondroom = double.Parse(room2);
            double thirdroom = double.Parse(room3);


            double equation1 = (firstroom * 10);
            double equation2 = (secondroom * 10);
            double equation3 = (thirdroom * 10);
            double equation4 = equation1 + equation2 + equation3;


            double renovationEquation = equation4;

            Result.Text = renovationEquation.ToString() + "$";
        }
    }
}


