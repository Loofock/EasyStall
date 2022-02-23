using EasyStall.Views;
using Xamarin.Forms;

namespace EasyStall
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProDashboardPage), typeof(ProDashboardPage));

            Routing.RegisterRoute(nameof(VisDashboardPage), typeof(VisDashboardPage));

            Routing.RegisterRoute(nameof(BenDashboardPage), typeof(BenDashboardPage));

            Routing.RegisterRoute(nameof(ProfileBenPage), typeof(ProfileBenPage));

            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));

            Routing.RegisterRoute(nameof(StandPage), typeof(StandPage));

        }

    }
}
