using EasyStall.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {

                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));

            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this,new PropertyChangedEventArgs("Username"));
            }

        }   


        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private async  void Register()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Username))
                await App.Current.MainPage.DisplayAlert("Champs Vides", "Remplissez Tous les champs", "OK");
            else
            {
                var user = await FirebaseHelper.AddUser(Email,Username,Password);
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Succès", "Vous vous êtes enregistré", "OK");
                    await App.Current.MainPage.Navigation.PushAsync(new MenuPage(Email));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Oops", "Il y a un problème ! ", "OK");
                }
            }
        }

    }
}
