using System.Threading.Tasks;
using AucService.Model;
using AucService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AucService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LotController : ControllerBase
    {
        // Status makeBet(price, userId, lotId)

        // Lot getLotStatus(lotId)
        
        // List<Lot> getAllLots()
        
        // List<Lot> getUserLots(userId)

        // User getUser(userId)
        
        private readonly IAuthService _userService;

        public LotController(IAuthService userService) => _userService = userService;

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var token = await _userService.Register(user);

            return Ok(token);
        }
    }
}