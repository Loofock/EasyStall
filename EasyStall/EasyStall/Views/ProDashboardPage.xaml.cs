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
    public partial class ProDashboardPage : ContentPage
    {

        ProDashboardViewModel proDashboardViewModel;
        public ProDashboardPage(User user)
        {
            InitializeComponent();
            proDashboardViewModel = new ProDashboardViewModel(user);
            BindingContext = proDashboardViewModel;
            
            
           
        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}