using System.Net;

namespace AddressServiceDAWA.Domain.DomainServices;

public interface IDawaProxy
{
    Task<GetDawaAddressResponse> GetDawaAddressAsync(string street, string building, string zipCode, string city);
}

public record GetDawaAddressResponse(
    bool DawaResponded = true,
    HttpStatusCode StatusCode = HttpStatusCode.Accepted,
    string DawaReasonPhrase = "",
    bool AddressFound = false,
    Guid Id = default,
    string Category = ""
    );