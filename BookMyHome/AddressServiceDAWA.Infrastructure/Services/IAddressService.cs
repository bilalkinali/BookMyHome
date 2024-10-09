namespace AddressServiceDAWA.Infrastructure.Services
{
    public interface IAddressService
    {
        Task<string> GetAddressDataMini(string vejnavn, string husnr, string postnr);
    }
}
