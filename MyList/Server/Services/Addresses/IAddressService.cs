using MyList.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyList.Server.Services.Addresses
{
    public interface IAddressService
    {
        Task<ServiceResponse<Address>> AddNewAddress(Address address);

        Task<ServiceResponse<List<Address>>> DeleteAddress(int id);

        Task<ServiceResponse<List<Address>>> GetAddressesAsync();
    }
}