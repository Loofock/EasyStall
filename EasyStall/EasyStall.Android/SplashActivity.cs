using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStall.Droid
{
    [Activity(Label = "EasyStall", Icon = "@drawable/AppIcon", MainLauncher = true, Theme ="@style/Loading.Splash", NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await SimulateStartup();
        }

        private async Task SimulateStartup()
        {
            /*await Task.Delay(6000);*/
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
} 