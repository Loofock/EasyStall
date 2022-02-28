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




        public ProfileBenPage(User user)
        {
            InitializeComponent();
            profileBenViewModel = new ProfileBenViewModel(user);
            BindingContext = profileBenViewModel;



        }

    }
}