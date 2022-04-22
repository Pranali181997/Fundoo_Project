using Database_Layer.Model;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Interface
{
    public interface IUserBL
    {
        public User Registration(UserRegistration userRegist);
        public string LogIn(string email, string password);
        public string ForgetPassword(string email);
    }
}