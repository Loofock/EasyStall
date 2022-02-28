using EasyStall.Models;
using EasyStall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListBenevolePage : ContentPage
    {
        
     

        public ListBenevolePage(User user)
        {
            InitializeComponent();
            

        }
        protected override async void OnAppearing()
        {
            var benevoles = await FirebaseHelper.GetAllBenevole();
            ListBenevole.ItemsSource = benevoles;

        }
    }
}