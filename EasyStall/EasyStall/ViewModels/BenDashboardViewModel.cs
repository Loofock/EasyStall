using EasyStall.Models;
using EasyStall.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EasyStall.ViewModels
{
    public class BenDashboardViewModel : INotifyPropertyChanged
    {

        public BenDashboardViewModel(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
            PhoneNumber = user.PhoneNumber;
            Description = user.Description;

        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        
        public string Age { get; set; }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string role;

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Role"));
            }
        }
        public Command Benbutton
        {
            get
            {
                return new Command(ProfilBenButton);
            }
        }

        private async void ProfilBenButton()
        {
            var user = await FirebaseHelper.GetUser(Email);
            if (user.FirstName != null)

                await App.Current.MainPage.Navigation.PushAsync(new ProfileBenPage(user));
            else
                await App.Current.MainPage.Navigation.PushAsync(new CreateProfileBenPage(user));
        }
        
    }
};
