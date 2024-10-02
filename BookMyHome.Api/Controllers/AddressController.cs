using Microsoft.AspNetCore.Mvc;
using BookMyHome.Infrastructure.ServiceAPI;

namespace BookMyHome.Api.Controllers
{
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
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
