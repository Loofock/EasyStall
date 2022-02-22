using EasyStall.ViewModels;
using EasyStall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EasyStall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StandPage : ContentPage
    {
        StandViewModel standViewModel;
        public StandPage(string Email)
        {
            InitializeComponent();
            standViewModel = new StandViewModel(Email);
            BindingContext = standViewModel;
        }


        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var stand = ((MenuItem)sender).BindingContext as Stand;
            if (stand == null)
                return;

            await DisplayAlert("Stand Réservé", "Retrouvez votre Stand Réservé sur votre Dashboard", "Retour");
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}