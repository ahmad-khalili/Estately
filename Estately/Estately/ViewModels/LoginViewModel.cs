using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Estately.Views;

namespace Estately
{

    public class LoginPageViewModel
    {

        public string WebAPIkey = "AIzaSyDQDD2D9NbLAKCUTvnqcxbArU0UfuQF0u8";


        public string Email { get; set; }
        public string Password { get; set; }
        public Command NoAccountCommand { get; set; }

        public async Task LoginUser()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Email is Empty!", "Ok");
            }
            else if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Password is Empty!", "Ok");

            }
            else
            {
                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);
                    var content = await auth.GetFreshAuthAsync();
                    var serializedcontnet = JsonConvert.SerializeObject(content);
                    Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                    await App.Current.MainPage.DisplayAlert("Welcome", Email, "Ok");
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", $"Incorrect Email or Password, {ex.Message}", "Ok");
                }

            }
        }


        /*public async void NavigateToRegister()
        {
           // await App.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }*/

        public ICommand LoginCommand { get; set; }


        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await LoginUser());
            NoAccountCommand = new Command(() => NoAccountPressed());
            //NoAccountCommand = new Command(async () => await NavigateToRegister());
        }

        public void NoAccountPressed()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }

    }
}


