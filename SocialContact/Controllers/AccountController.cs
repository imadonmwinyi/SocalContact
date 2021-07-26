using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialContact.Common;
using SocialContact.Core.Services.Abstraction;
using SocialContact.Data.DTOs;
using SocialContact.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IEmailService _emailService;

        public AccountController(UserManager<AppUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }
        [HttpGet]
        public string Get()
        {
            return "Account Coming Soon...";
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Utilities.CreateResponse<string>("", ModelState, ""));
            }
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName

            };
            var userCreated = await _userManager.CreateAsync(user, model.Password);
            if (userCreated.Succeeded)
            {
                var queryParam = new Dictionary<string, string>
                { 
                    { "email", user.Email }, 
                    { "token", await _userManager.GenerateEmailConfirmationTokenAsync(user) } 
                };
                var content = NotificationHelper.EmailSenderNotification($"{user.FirstName} {user.LastName}", "Account/EmailActivation", queryParam, "EmailActivation.html", HttpContext);
                _emailService.SendEmail(user.Email, content, "Email Confirmation");

                return Created("",Utilities.CreateResponse<string>("User Registration successful", null, ""));
            }
            else
            {
                foreach (var err in userCreated.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }

                return BadRequest(Utilities.CreateResponse<string>("Error", ModelState, ""));
            }
            
        }

    }
}
