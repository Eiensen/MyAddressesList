using MyList.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyList.Server.Services.Addresses
{
    public interface IAddressService
    {
        Task<ServiceResponse<Address>> AddNewAddress(Address address);

        Task<ServiceResponse<Address>> DeleteAddress(int id);

        ServiceResponse<IEnumerable<Address>> GetAddressesAsync();
    }
}