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
    public partial class VisDashboardPage : ContentPage
    {
        VisDashboardViewModel visDashboardViewModel;
        public VisDashboardPage(User user)
        {
            InitializeComponent();

            visDashboardViewModel = new VisDashboardViewModel(user);
            BindingContext = visDashboardViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}