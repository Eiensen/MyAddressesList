using MyList.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyList.Server.Services.Addresses
{
    public interface IAddressService
    {
        Task<ServiceResponse<List<Address>>> GetAddressesAsync();
    }
}