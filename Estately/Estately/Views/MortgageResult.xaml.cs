using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Estately.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MortgageResult : ContentPage
    {
        public MortgageResult(string housePrice, string loanLength, string downPayment, double interestRate)
        {
            InitializeComponent();
            
            HousePrice.Text = "$" + housePrice;
            DownPayment.Text = "$" + downPayment;
            InterestRate.Text = "%" + interestRate.ToString();
            LoanLength.Text = loanLength + " Years";

            double price = double.Parse(housePrice);
            double amount = double.Parse(loanLength);
            double payment = double.Parse(downPayment);

            double i = ((interestRate / 100) / 12);
            double n = amount * 12;

            double equation1 = (i * Math.Pow((i + 1), n));
            double equation2 = (Math.Pow((i + 1), n) - 1);

            double principle = price - payment;

            double mortgageEquation = Math.Round((principle * equation1) / equation2);

            Result.Text = mortgageEquation.ToString() + "$";

        }
    }
}
