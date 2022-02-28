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
    public partial class CreateProfileBenPage : ContentPage
    {
        CreateProfileBenViewModel createProfileBenViewModel;
        public CreateProfileBenPage(User user)
        {
            InitializeComponent();
            createProfileBenViewModel = new CreateProfileBenViewModel(user);
            BindingContext = createProfileBenViewModel;
            
            
        }
    }
}