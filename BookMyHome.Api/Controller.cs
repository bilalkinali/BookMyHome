using Microsoft.AspNetCore.Mvc;
using BookMyHome.Infrastructure.ServiceAPI;

namespace BookMyHome.Api
{
    public class Controller : ControllerBase
    {
        private readonly IAddressService _addressService;

        public Controller(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<string> Something()
        {
            return await _addressService.Something();
        }
    }
}
