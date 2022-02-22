using EasyStall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStall.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MenuViewModel menuViewModel;
        public MenuPage(string Email)
        {
            InitializeComponent();
            
            menuViewModel = new MenuViewModel(Email);
            BindingContext = menuViewModel; 
        }

        

    }
}