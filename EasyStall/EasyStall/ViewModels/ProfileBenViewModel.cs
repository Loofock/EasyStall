using EasyStall.Models;
using EasyStall.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class ProfileBenViewModel : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }

        private string descriptionTxt;

        public event PropertyChangedEventHandler PropertyChanged;
        public string DescriptionTxt
        {
            get { return descriptionTxt; }
            set
            {
                descriptionTxt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DescriptionTxt"));
            }
        }


        public ProfileBenViewModel(User user)
        {
            Email = user.Email;
            UserName = user.UserName;
            Password = user.Password;
            Role = user.Role;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
            PhoneNumber = user.PhoneNumber;

        }

        public Command DescriptionCommand
        {
            get
            {
                return new Command(Description);
            }
        }

        private async void Description()
        {
            if (string.IsNullOrWhiteSpace(DescriptionTxt))
                await App.Current.MainPage.DisplayAlert("Champs Vides", "Remplissez Tous les champs", "OK");
            else
            {   
                
                var user = await FirebaseHelper.AddBenevole(Email, UserName, Password, Role, FirstName, LastName, Age ,PhoneNumber, DescriptionTxt);
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Succès", "Profil mis a jour !", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Oops", "Il y a un problème ! ", "OK");
                }
            }
        }
        public Command RetourCommand
        {
            get
            {
                return new Command(Retour);
            }
        }

        private async void Retour()
        {
            var user = await FirebaseHelper.GetUser(Email);
            await App.Current.MainPage.Navigation.PushAsync(new BenDashboardPage(user));
        }


    }
}
