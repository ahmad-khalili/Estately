using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Estately.Views;
using Xamarin.Forms.Xaml;

namespace Estately
{
    public class RegistrationViewModel
    {
        public string WebAPIkey = "AIzaSyDQDD2D9NbLAKCUTvnqcxbArU0UfuQF0u8";
        public string Email { get; set; }
        public string Password { get; set; }
        public Command AlreadyUserCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public async Task RegisterUser()
        {
            if (Email == null)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Email is Empty", "Ok");
            }

            if (Password == null)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Password is Empty", "Ok");
            }

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Success", Email, "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", $"Invalid Email or Password!, {ex.Message}", "OK");
            }

        }
        public RegistrationViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterUser());
            AlreadyUserCommand = new Command(() => AlreadyUserPressed());
        }

        public void AlreadyUserPressed()
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}