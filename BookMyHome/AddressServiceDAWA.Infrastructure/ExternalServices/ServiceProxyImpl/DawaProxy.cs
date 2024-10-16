using System.Text.Json.Nodes;
using AddressServiceDAWA.Domain.DomainServices;

namespace AddressServiceDAWA.Infrastructure.ExternalServices.ServiceProxyImpl
{
    public class DawaProxy : IDawaProxy
    {
        private readonly HttpClient _httpClient;

        public DawaProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<GetDawaAddressResponse> IDawaProxy.GetDawaAddressAsync(string street, string building, string zipCode, string city)
        {
            var requestUri = $"/datavask/adresser?betegnelse={street} {building}, {zipCode} {city}";
            var dawaResponse = await _httpClient.GetAsync(requestUri);

            if (!dawaResponse.IsSuccessStatusCode)
            {
                return new GetDawaAddressResponse(false, dawaResponse.StatusCode, dawaResponse.ReasonPhrase ?? "", Id: Guid.Empty);
            }

            var jsonResponse = await dawaResponse.Content.ReadAsStringAsync();
            JsonNode dawaNode = JsonNode.Parse(jsonResponse)!;
            var kategoriNode = dawaNode["kategori"];
            var resultaterNode = dawaNode["resultater"];
            var adresseNode = resultaterNode![0]!["adresse"];
            var dawaIdNode = adresseNode!["id"];


            if (kategoriNode != null
                && Guid.TryParse(dawaIdNode?.ToString() ?? string.Empty, out Guid dataId))
            {
                return new GetDawaAddressResponse(AddressFound: true, Id: dataId, Category: kategoriNode.ToString());
            };

            return new GetDawaAddressResponse(false, Id: Guid.Empty);
        }
    }
}
