using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

       
        /*
        protected override async void OnAppearing()
        {
            var loggedin = true;
            if(loggedin)
                await Shell.Current.GoToAsync($"//{ nameof(MenuPage)}");
        }
        */
        private async void Register_Pressed(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{ nameof(RegisterPage)}");
        }
    }
}