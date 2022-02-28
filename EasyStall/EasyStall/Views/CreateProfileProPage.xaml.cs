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
    public partial class CreateProfileProPage : ContentPage
    {
        CreateProfileProViewModel createProfileProViewModel;
        public CreateProfileProPage(User user)
        {
            InitializeComponent();
            createProfileProViewModel = new CreateProfileProViewModel(user);
            BindingContext = createProfileProViewModel;
        }
    }
}