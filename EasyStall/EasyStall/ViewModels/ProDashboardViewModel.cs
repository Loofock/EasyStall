using EasyStall.Views;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class ProDashboardViewModel : INotifyPropertyChanged
    {

        public ProDashboardViewModel(string email)
        {
            Email = email;

        }

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

        public Command StandMove
        {
            get
            {
                return new Command(StandButton);
            }
     
        }
        private async void StandButton()
        {
            await App.Current.MainPage.Navigation.PushAsync(new StandPage(Email));
        }

    }
}
