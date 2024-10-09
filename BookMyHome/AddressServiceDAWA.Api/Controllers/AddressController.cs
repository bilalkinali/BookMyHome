using AddressServiceDAWA.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressServiceDAWA.Api.Controllers
{
    //[Route("api/adresser")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [Route("api/adresser")]
        public async Task<string> GetAddressInfo([FromQuery]string vejnavn, [FromQuery]string husnr, [FromQuery]string postnr)
        {
            return await _addressService.GetAddressDataMini(vejnavn, husnr, postnr);
        }
    }
}
