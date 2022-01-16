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
        private readonly IBetService _betService;

        public LotController(IBetService betService) => _betService = betService;

        [HttpPost]
        public async Task<IActionResult> MakeBet(int userId, int lotId, int newPrice)
        {
            await _betService.MakeBet(userId, lotId, newPrice);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> getLotStatus(int lotId)
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> getAllLots()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> getUserLots(int userId)
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> getUser(int userId)
        {
            
        }
    }
}