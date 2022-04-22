using Business_Layer.Interface;
using Database_Layer.Model;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Project.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        FundooContext fundoo;
        //Constructor
        public UserController(IUserBL userBL,FundooContext fundoo)
        {
            this.userBL = userBL;
            this.fundoo = fundoo;
        }
        //Register a User
        [HttpPost("Register")]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                var getUserData = fundoo.UserTable.FirstOrDefault(u => u.Email == userRegistration.Email);
                if (getUserData != null)
                {
                    return this.Ok(new { success = false, message = $"{userRegistration.Email} is Already Exists" });
                }
                this.userBL.Registration(userRegistration);
                return this.Ok(new { success = true, message = $"Registration Successfull { userRegistration.Email}" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //User Login
        [HttpPost("Login")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                var user = userBL.LogIn(userLogin.Email, userLogin.Password);
                if (user != null)
                    return this.Ok(new { Success = true, message = "Logged In", data = user });
                else
                    return this.BadRequest(new { Success = false, message = "Enter Valid Email and Password" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Forget Password
        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var user = userBL.ForgetPassword(email);
                if (user != null)
                    return this.Ok(new { Success = true, message = "Email sent", data = user });
                else
                    return this.BadRequest(new { Success = false, message = "Email not sent" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
