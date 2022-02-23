using EasyStall.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EasyStall.ViewModels
{
    public class ProfileBenViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }


        


        public ProfileBenViewModel(string email)
        {
            Email = email;
           
            



        }
        private string email;
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
