using CartCar.App.Models.Entities;
using CartCar.App.Models.Services;
using Microsoft.AspNetCore.SignalR;

namespace CartCar.App.Hubs
{
    public class SiteHub: Hub
    {
        private readonly IDrivingOffenseService _offenseService;
        public SiteHub(IDrivingOffenseService drivingOffenseService)
        {
            _offenseService = drivingOffenseService;
        }
        public async Task SearchTagcarToCartcar(string part1, Specialcharacters part2, string part3, string part4)
        {
            var result = _offenseService.SearchTagCarToCartcar(part1, part2, part3, part4);
            if(result != null)
            {
                await Clients.Caller.SendAsync("getSearchResultCartcar", result);
            }
        }

        public async Task SearchResultInfractionCar(long code)
        {
            var result = _offenseService.SearchInfractioncar(code);
            if(result != null)
            {
                await Clients.Caller.SendAsync("getSearchResultInfractionCar", result);
            }
        }
    }
}
