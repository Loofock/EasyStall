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
    public partial class BenDashboardPage : ContentPage
    {
        BenDashboardViewModel benDashboardViewModel;
        public BenDashboardPage(string Email)
        {
            InitializeComponent();
            benDashboardViewModel = new BenDashboardViewModel(Email);
            BindingContext = benDashboardViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}