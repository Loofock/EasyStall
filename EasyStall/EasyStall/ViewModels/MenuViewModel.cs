using EasyStall.Models;
using EasyStall.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public MenuViewModel(User user)
        {
            Email = user.Email;
            

        }

        

        private string email;

        public string Email 
        {   get { return email; }
            set { email= value; } 
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Password
        {
            get { return password; }
            set { password = value;}
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value;}
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
        public Command ProRoleCommand
        {
            get
            {
                return new Command(UpdatePro);


            }
        }

        private async void UpdatePro()
        {
            var user = await FirebaseHelper.GetUser(Email);
            
            if (user != null)
            {
                string Pro = "Pro";

                await FirebaseHelper.UpdateUserRole(user.Email,user.UserName,user.Password, Pro);
                await App.Current.MainPage.Navigation.PushAsync(new ProDashboardPage(user));
            }
            else
                await App.Current.MainPage.DisplayAlert("Oopsies", "User not found", "OK");



        }
        public Command VisRoleCommand
        {
            get
            {
                return new Command(UpdateVis);


            }
        }
        private async void UpdateVis()
        {
            var user = await FirebaseHelper.GetUser(Email);

            if (user != null)
            {
                string Vis = "Vis";

                await FirebaseHelper.UpdateUserRole(user.Email, user.UserName, user.Password, Vis);
                await App.Current.MainPage.Navigation.PushAsync(new VisDashboardPage(user));
            }
            else
                await App.Current.MainPage.DisplayAlert("Oopsies", "User not found", "OK");


        }
        public Command BenRoleCommand
        {
            get
            {
                return new Command(UpdateBen);


            }
        }
        private async void UpdateBen()
        {
            var user = await FirebaseHelper.GetUser(Email);

            if (user != null)
            {
                string Ben = "Ben";

                await FirebaseHelper.UpdateUserRole(user.Email, user.UserName, user.Password, Ben );
                await App.Current.MainPage.Navigation.PushAsync(new BenDashboardPage(user));
            }
            else
                await App.Current.MainPage.DisplayAlert("Oopsies", "User not found", "OK");


        }
        /*
        private async void UserCheckRole()
        {
            var user = await FirebaseHelper.GetUser(Email);

            if (user.Role != null)
            {
                switch (user.Role)
                {
                    case ("Pro"):
                        await Shell.Current.GoToAsync($"{ nameof(ProDashboardPage)}");
                        break;
                    case ("Vis"):
                        await Shell.Current.GoToAsync($"{ nameof(VisDashboardPage)}");
                        break;
                    case ("Ben"):
                        await Shell.Current.GoToAsync($"{ nameof(BenDashboardPage)}");
                        break;

                }
                    
            }
        }
        */
    }
}
