using EasyStall.Models;
using EasyStall.Views;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class ProDashboardViewModel : INotifyPropertyChanged
    {

        public ProDashboardViewModel(User user)
        {
            Email = user.Email;
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            CompanyName = user.CompanyName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }

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

        public string UserName { get; set; }
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
        public Command BenevoleListCommand
        {
            get
            {
                return new Command(BenevoleList);
            }

        }
        private async void BenevoleList()
        {
            var user = await FirebaseHelper.GetUser(Email);
            await App.Current.MainPage.Navigation.PushAsync(new ListBenevolePage(user));
        }



        public Command StandListCommand
        {
            get
            {
                return new Command(StandList);
            }

        }
        private async void StandList()
        {
            var user = await FirebaseHelper.GetUser(Email);
            await App.Current.MainPage.Navigation.PushAsync(new StandPage(user));
        }



        public Command ProButton
        {
            get
            {
                return new Command(ProfilProButton);
            }
        }

        private async void ProfilProButton()
        {
            var user = await FirebaseHelper.GetUser(Email);
            await App.Current.MainPage.Navigation.PushAsync(new CreateProfileProPage(user));

        }

    }
}



