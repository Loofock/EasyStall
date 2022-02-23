using EasyStall.Models;
using EasyStall.ViewModels;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileBenPage : ContentPage
    {
        ProfileBenViewModel profileBenViewModel;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }


        public ProfileBenPage(string Email)
        {
            InitializeComponent();
            profileBenViewModel = new ProfileBenViewModel(Email);
            BindingContext = profileBenViewModel;



        }

    }
}