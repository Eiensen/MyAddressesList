using MyList.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyList.Server.Services.Addresses
{
    public interface IAddressService
    {
        Task<ServiceResponse<Address>> AddNewAddressAsync(Address address);

        Task<ServiceResponse<Address>> DeleteAddressAsync(int id);

        ServiceResponse<IEnumerable<Address>> GetAddressesAsync();

        Task<ServiceResponse<Address>> GetAddressByIdAsync(int id);

        Task<ServiceResponse<IEnumerable<Address>>> UpdateAddressAsync(int id, Address address);

        Task<ServiceResponse<IEnumerable<Address>>> SearchForAddressesByMeasurmentAsync(DateTime startDate, DateTime endDate);

        Task<ServiceResponse<IEnumerable<Address>>> SearchForAddressesByMontageAsync(DateTime startDate, DateTime endDate);

        Task<ServiceResponse<IEnumerable<Address>>> SearchForAddressesByWorkersAsync(DateTime startDate, DateTime endDate, string worker);
    }
}