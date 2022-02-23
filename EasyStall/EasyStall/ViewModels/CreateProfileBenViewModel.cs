using EasyStall.Views;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class CreateProfileBenViewModel : INotifyPropertyChanged
    {
        public CreateProfileBenViewModel(string email)
        {
            Email = email;

        }
        private string email;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }

        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }

        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PhoneNumber"));
            }

        }
        public Command NewProfileCommand
        {
            get
            {
                return new Command(NewProfile);
            }
        }
        private async void NewProfile()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(PhoneNumber))
                await App.Current.MainPage.DisplayAlert("Champs Vides", "Remplissez Tous les champs", "OK");
            else
            {
                var user = await FirebaseHelper.GetUser(Email);
                if (user != null)
                {
                    string LastName = lastName;
                    string FirstName = firstName;
                    string PhoneNumber = phoneNumber;

                    await FirebaseHelper.UpdateUserProfile(user.Email, user.UserName, user.Password, user.Role, FirstName, LastName, PhoneNumber);
                    await App.Current.MainPage.Navigation.PushAsync(new ProfileBenPage(Email));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Oops", "Il y a un problème ! ", "OK");
                }
            }
        }
        
    }
}
