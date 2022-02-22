using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EasyStall.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Auth;
using System.Threading.Tasks;

namespace EasyStall.Droid
{
    public class FirebaseAuthentication : AuthService
    {
        /*
        public async Task<bool> CreateUser(string username, string email, string password)
        {
            try
            {
                var authResult = await FirebaseAuth.Instance
                    .CreateUserWithEmailAndPasswordAsync(email, password);

                var UserProfileChangeRequest = await authResult.User.UpdateProfileAsync();
                UserProfileChangeRequest.DisplayName = username;
                await UserProfileChangeRequest.CommitChangesAsync();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex .Message);

                return await Task.FromResult(false);
            }
        }
        
        public bool IsSignedIn()
        {
            var CurrentUser = FirebaseAuth.Instance.CurrentUser;
            return CurrentUser != null;
        }
        */
    }
}