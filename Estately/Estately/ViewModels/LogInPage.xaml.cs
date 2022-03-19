using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Auth
{
    public partial class MainPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDQDD2D9NbLAKCUTvnqcxbArU0UfuQF0u8";

        public MainPage()
        {
            InitializeComponent();
        }

        async void signupbutton_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }

        async void loginbutton_Clicked(Object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Navigation.PushAsync(new MyDashboardPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }
        }
    }
}
