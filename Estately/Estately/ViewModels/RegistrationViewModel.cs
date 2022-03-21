using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Estately
{
    public class RegistrationViewModel
    {
        public string WebAPIkey = "AIzaSyDQDD2D9NbLAKCUTvnqcxbArU0UfuQF0u8";

        /* async void signupbutton_Clicked(Object sender, EventArgs e)
         {
             try
             {
                 var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                 var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                 string gettoken = auth.FirebaseToken;
                 await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");
             }
             catch (Exception ex)
             {
                 await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
             }*/

    }
}
