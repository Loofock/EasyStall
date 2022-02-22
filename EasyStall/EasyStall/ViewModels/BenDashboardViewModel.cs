using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EasyStall.ViewModels
{
    public class BenDashboardViewModel : INotifyPropertyChanged
    {

        public BenDashboardViewModel(string email)
        {
            Email = email;

        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string role;

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Role"));
            }
        }

    }
}
