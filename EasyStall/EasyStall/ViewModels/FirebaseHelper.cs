using EasyStall.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStall.ViewModels
{
    public class FirebaseHelper
    {
        public static FirebaseClient Firebase = new FirebaseClient("https://easystall-73630-default-rtdb.europe-west1.firebasedatabase.app/");

        public static async Task<List<User>> GetAllUser()
        {
            try
            {
                var userlist = (await Firebase
                    .Child("User")
                    .OnceAsync<User>()).Select(item =>
                    new User
                    {
                        Email = item.Object.Email,
                        Password = item.Object.Password,
                        UserName = item.Object.UserName,
                        Role = item.Object.Role,
                    }).ToList();
                  return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        internal static Task UpdateUser(object email, object username, object password, string role)
        {
            throw new NotImplementedException();
        }

        public static async Task<User> GetUser(string Email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await Firebase
                .Child("User")
                .OnceAsync<User>();
                return allUsers.Where(a => a.Email == Email).FirstOrDefault();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> AddUser(string Email, string UserName, string Password)
        {
            try
            {   
                await Firebase.Child("User")
                    .PostAsync(new User() { Email = Email, UserName = UserName, Password = Password });
                return true;


            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public async Task<bool> UpdateUser(string Email, string Username, string Password,string Role)
        {
            try
            {
                var toUpdateUser = (await Firebase
                    .Child("User")
                    .OnceAsync<User>())
                    .Where(a => a.Object.Email == Email).FirstOrDefault();
                await Firebase
                    .Child("User")
                    .Child(toUpdateUser.Key)
                    .PutAsync(new User() { Email = Email, UserName = Username,  Password = Password, Role = Role });
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        
        public static async Task<bool> UpdateUserRole(string Email, string Username, string Password, string Role)
        {
            try
            {
                var toUpdateUser = (await Firebase
                    .Child("User")
                    .OnceAsync<User>())
                    .Where(a => a.Object.Email == Email).FirstOrDefault();
                await Firebase
                    .Child("User")
                    .Child(toUpdateUser.Key)
                    .PutAsync(new User() { Email = Email, UserName = Username, Password = Password, Role = Role });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public async Task<bool> DeleteUser(string Email)
        {
            try
            {
                var toDeleteUser = (await Firebase
                    .Child("User")
                    .OnceAsync<User>())
                    .Where(a => a.Object.Email == Email).FirstOrDefault();
                await Firebase
                    .Child("User")
                    .Child(toDeleteUser.Key).DeleteAsync();
                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
    }
}
