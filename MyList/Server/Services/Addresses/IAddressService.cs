using MyList.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyList.Server.Services.Addresses
{
    public interface IAddressService
    {
        Task<ServiceResponse<Address>> AddNewAddress(Address address);

        Task<ServiceResponse<Address>> DeleteAddress(int id);

        ServiceResponse<IEnumerable<Address>> GetAddressesAsync();

        Task<ServiceResponse<Address>> GetAddressById(int id);

        Task<ServiceResponse<IEnumerable<Address>>> UpdateAddress(int id, Address address);

        Task<ServiceResponse<IEnumerable<Address>>> SearchForMeasurment(DateTime startDate, DateTime endDate);
    }
}