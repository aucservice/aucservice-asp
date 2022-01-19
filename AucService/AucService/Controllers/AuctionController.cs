using System.Threading.Tasks;
using AucService.Model;
using AucService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AucService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        private readonly IBetService _betService;
        
        public AuctionController(IBetService betService)
        {
            _betService = betService;
        }

        [HttpPost("bid")]
        public async Task<IActionResult> MakeBid(BidReceive receive)
        {
            await _betService.MakeBid(receive.name, receive.lotId, receive.amount, receive.token);

            return Ok();
        }

        [HttpGet("lot")]
        public async Task<IActionResult> GetLotById(string lotId)
        {
            var lot = await _betService.GetLot(lotId);

            if (lot is null)
                return BadRequest(new { message = "Invalid Lot Id" });

            return Ok(lot);
        }

        [HttpGet("lots")]
        public async Task<IActionResult> GetAllLots()
        {
            var lots = await _betService.GetAllLots();

            if (lots is null)
                return BadRequest(new { message = "Lots is empty!" });

            return Ok(lots);
        }

        [HttpPut("user")]
        public async Task<IActionResult> GetUser(string name)
        {
            var user = await _betService.GetUser(name);

            if (user is null)
                return BadRequest(new { message = "Invalid User Id" });

            return Ok(user);
        }
        
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers(string token)
        {
            var users = await _betService.GetUsers(token);

            if (users is null)
                return BadRequest(new { message = "Invalid User Id" });

            return Ok(users);
        }
    }
}