using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AucService.Model;
using AucService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AucService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var t = await _userService.TestApi();

            return Ok(t);
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (user is null)
                return BadRequest(new { message = "Invalid User" });
            
            var token = await _userService.Register(user);
        
            return Ok(token);
        }
        
        [HttpPost]
        public async Task<IActionResult> LogIn(UserRequest request)
        {
            if (request is null)
                return BadRequest(new { message = "Invalid User" });
            
            var token = await _userService.LogIn(request);
        
            return Ok(token);
        }
    }
}