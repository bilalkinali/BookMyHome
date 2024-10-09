namespace AddressServiceDAWA.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<string> IAddressService.GetAddressDataMini(string vejnavn, string husnr, string postnr)
        {
            try
            {
                var result = await _httpClient.GetAsync(
                        $"adresser?vejnavn={vejnavn}&husnr={husnr}&postnr={postnr}&struktur=mini");

                if (result.IsSuccessStatusCode)
                    return await result.Content.ReadAsStringAsync();

                // Status codes 

            }
            catch (Exception)
            {

                throw;
            }

            return "";
        }
    }
}
