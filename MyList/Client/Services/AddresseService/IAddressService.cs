using MyList.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyList.Client.Services.AddresseService
{
    public interface IAddressService
    {
        List<Address> Addresses { get; set; }

        Task AddNewAddress(Address address);

        Task DeleteAddress(int id);

        Task<List<Address>> GetAddresses();

        Task<Address> GetAddressById(int id);

        Task UpdateAddress(Address address);

        Task<IEnumerable<Address>> SearchForAddressesByMeasurment(DateTime startDate, DateTime endDate);

        Task<IEnumerable<Address>> SearchForAddressesByMontage(DateTime startDate, DateTime endDate);
    }
}
