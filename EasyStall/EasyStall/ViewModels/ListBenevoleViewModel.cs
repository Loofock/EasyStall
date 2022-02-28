using EasyStall.Models;
using EasyStall.Views;
using Firebase.Database;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace EasyStall.ViewModels
{
    public class ListBenevoleViewModel : BaseViewModel
    {




        public ListBenevoleViewModel(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
            PhoneNumber = user.PhoneNumber;
            Description = user.Description;
            /*
            services = new FirebaseHelper();
            Benevoles = services.GetBenevoles();
            */

        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }

        public string Description { get; set; }

/*
        private FirebaseHelper services;

        private ObservableCollection<User> benevoles = new ObservableCollection<User>();
        public ObservableCollection<User> Benevoles
        {
            get { return benevoles; }
            set { benevoles = value; OnPropertyChanged(); }
        }
*/


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
            await App.Current.MainPage.Navigation.PushAsync(new ProDashboardPage(user));

        }
    }
}
