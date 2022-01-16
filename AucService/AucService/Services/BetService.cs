using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AucService.Model;

namespace AucService.Services
{
    public class BetService : IBetService
    {
        private readonly HttpClient _client;

        public BetService(HttpClient client) => _client = client;

        public Task MakeBet(int price, int userId, int lotId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Lot> GetLotStatus(int lotId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Lot>> GetAllLots()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Lot>> GetUserLots(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUser(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}