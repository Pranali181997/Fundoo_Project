﻿
using Business_Layer.Interface;
using Database_Layer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        //Constructor
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        //Register a User
        [HttpPost("Register")]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                var result = userBL.Registration(userRegistration);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Registration successful", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Registration Unsuccessful" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}