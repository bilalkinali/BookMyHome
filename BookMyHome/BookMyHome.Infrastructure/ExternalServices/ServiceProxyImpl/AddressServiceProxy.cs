using System.Net.Http.Json;

namespace BookMyHome.Infrastructure.ExternalServices.ServiceProxyImpl
{
    public class AddressServiceProxy : IAddressServiceProxy
    {
        private readonly HttpClient _client;

        public AddressServiceProxy(HttpClient client)
        {
            _client = client;
        }
        async Task<AddressValidationResultDto> IAddressServiceProxy.ValidateAddressAsync(string street, string building, string zipCode)
        {
            var requestDto = new AddressValidationRequestDto(street, building, zipCode);
            var response = await _client.PostAsJsonAsync("/Address", requestDto);
            if (!response.IsSuccessStatusCode) return new AddressValidationResultDto(string.Empty, AddressValidationStateDto.Valid);
            var result = await response.Content.ReadFromJsonAsync<AddressValidationResultDto>();
            return result ?? new AddressValidationResultDto(string.Empty, AddressValidationStateDto.Valid);
        }
    }
}
