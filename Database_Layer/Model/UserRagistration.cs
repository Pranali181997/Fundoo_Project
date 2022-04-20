using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Layer.Model
{
    public class UserRegistration
    {
        //User Registration Entity
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}