using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Estately.ViewModels;
using System.Reflection;

namespace Estately.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RennovationPage : ContentPage
    {
        public RennovationPage()
        {
            InitializeComponent();
            BindingContext = new RenovationViewModel();
        }
     

    }
}



