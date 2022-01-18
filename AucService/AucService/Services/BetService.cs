using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AucService.Model;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using AucService.Hubs;
using System;
using System.Net.Http.Headers;

namespace AucService.Services
{
    public class BetService : IBetService
    {
        private readonly HttpClient _client;
        private readonly IHubContext<AuctionHub> _hub;

        private const string BaseUri = "https://aucservice.fpmi.spiralarms.org";

        public BetService(HttpClient client, IHubContext<AuctionHub> hub)
        {
            _client = client;
            _hub = hub;
        }

        public async Task MakeBid(string userName, string lotId, int amount, string token)
        {
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUri),
                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", token) }
            };

            var jsonBid = await httpClient.GetAsync($"{BaseUri}/my_bid/{lotId}");
            var currBid = await jsonBid.Content.ReadFromJsonAsync<Bid>();

            if (DateTime.Now.Second - currBid.timestamp <= 3600)
            {
                await httpClient.PutAsJsonAsync($"{BaseUri}/my_bid/{lotId}", amount);
                await _hub.Clients.All.SendAsync("bid", userName, lotId, amount);
            }
            else
            {
                await _hub.Clients.All.SendAsync("bid-end", "Bets are over!!!");
                await httpClient.DeleteAsync($"{BaseUri}/my_bid/{lotId}");
            }
        }

        public async Task<Dictionary<string, Lot>> GetAllLots()
        {
            var lots = await _client.GetAsync($"{BaseUri}/lots");
            return await lots.Content.ReadFromJsonAsync<Dictionary<string, Lot>>();
        }

        public async Task<Lot> GetLot(string lotId)
        {
            var lot = await _client.GetAsync($"{BaseUri}/lot/{lotId}");
            return await lot.Content.ReadFromJsonAsync<Lot>();
        }

        public async Task<UserAndLots> GetUser(string username)
        {
            var _ = await _client.GetAsync($"{BaseUri}/bids");
            var bids = _.Content.ReadFromJsonAsync<Dictionary<string, Bid>>();


            var userBids = bids.Result.Values.Where(x => x.username == username);

            var taskLots = await GetAllLots();

            var lots = from bid in userBids
                       join lot in taskLots.Values
                       on bid.lot_id equals lot.id
                       select lot;

            return new UserAndLots { username = username, lots = lots };
        }
    }
}