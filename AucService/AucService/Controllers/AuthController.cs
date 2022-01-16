using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AucService.Model;
using AucService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AucService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var token = await _userService.Register(user);

            return Ok(token);
        }
        
        [HttpPost]
        public async Task<IActionResult> LogIn(UserRequest request)
        {
            var token = await _userService.LogIn(request);

            return Ok(token);
        }
    }
}