using System.Collections.Generic;
using System.Threading.Tasks;
using AucService.Model;

namespace AucService.Services
{
    public interface IBetService
    {
        Task MakeBid(string userName, string lotId, int amount, string token);

        Task<Lot> GetLot(string lotId);

        Task<Dictionary<string, Lot>> GetAllLots();

        Task<UserAndLots> GetUser(string userName);
    }
}