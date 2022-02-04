using MyList.Shared;
using System.Collections.Generic;

namespace UseCases
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
    }
}