using EasyStall.Models;
using EasyStall.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class CreateProfileProViewModel : INotifyPropertyChanged
    {
        public CreateProfileProViewModel(User user)
        {
            Email = user.Email;


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

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CompanyName"));
            }

        }
        public Command RetourButton
        {
            get
            {
                return new Command(Retour);
            }
        }

        private async void Retour()
        {
            var user = await FirebaseHelper.GetUser(Email);
            await App.Current.MainPage.Navigation.PushAsync(new ProDashboardPage(user));

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
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(CompanyName))
                await App.Current.MainPage.DisplayAlert("Champs Vides", "Remplissez Tous les champs", "OK");
            else
            {
                var user = await FirebaseHelper.GetUser(Email);
                if (user != null)
                {
                    string LastName = lastName;
                    string FirstName = firstName;
                    string CompanyName = companyName;
                    

                    await FirebaseHelper.UpdateUserProfile(user.Email, user.UserName, user.Password, user.Role, FirstName, LastName, CompanyName, user.Age, user.PhoneNumber);
                    await App.Current.MainPage.Navigation.PushAsync(new ProDashboardPage(user));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Oops", "Il y a un problème ! ", "OK");
                }
            }
        }
    }
}
