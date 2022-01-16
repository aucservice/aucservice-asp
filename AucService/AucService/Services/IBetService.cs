using System.Collections.Generic;
using System.Threading.Tasks;
using AucService.Model;

namespace AucService.Services
{
    public interface IBetService
    {
        Task MakeBet(int price, int userId, int lotId);

        Task<Lot> GetLotStatus(int lotId);

        Task<IEnumerable<Lot>> GetAllLots();

        Task<IEnumerable<Lot>> GetUserLots(int userId);

        Task<User> GetUser(int userId);
    }
}