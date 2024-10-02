namespace BookMyHome.Infrastructure.ServiceAPI
{
    public class AddressAPI : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<string> IAddressService.Something()
        {
            return await _httpClient.GetStringAsync("test");
        }
    }
}
