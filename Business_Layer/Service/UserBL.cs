using Business_Layer.Interface;
using Database_Layer.Model;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Service
{
    //Service Class of Business Layer
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        //Constructor
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        //Method to return UserRegistration obj to Repo Layer User.
        public User Registration(UserRegistration userRegist)
        {
            try
            {
                return userRL.Registration(userRegist);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}