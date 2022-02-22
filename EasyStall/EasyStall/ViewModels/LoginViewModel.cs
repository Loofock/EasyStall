using EasyStall.Services;
using EasyStall.Views;
using Xamarin.Forms;

namespace EasyStall.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Email { get;  set; }
        public string Password { get;  set; }


        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Champs Vides", "Veuillez remplir les Champs Mot de passe et Nom de Compte", "Retour");
            else
            {
                var user = await FirebaseHelper.GetUser(Email);
                if (user != null)
                    if (Email == user.Email && Password == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Connexion !", "Connexion Réussie", "Ok");
                        if (user.Role != null)
                        {
                            switch (user.Role)
                            {
                                case ("Pro"):
                                    await App.Current.MainPage.Navigation.PushAsync(new ProDashboardPage(Email));
                                    break;
                                case ("Vis"):
                                    await App.Current.MainPage.Navigation.PushAsync(new VisDashboardPage(Email));
                                    break;
                                case ("Ben"):
                                    await App.Current.MainPage.Navigation.PushAsync(new BenDashboardPage(Email));
                                    break;

                            }

                        }
                        else
                        await App.Current.MainPage.Navigation.PushAsync(new MenuPage(Email));

                    }
                else
                    await App.Current.MainPage.DisplayAlert("Erreur", "Entrez le bon email et mot de passe", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Oops", "Votre Compte n'existe pas ! Créez en un !", "OK");

            }
        }
    }

  
}
