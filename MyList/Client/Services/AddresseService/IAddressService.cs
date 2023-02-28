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

        Task AddNewAddressAsync(Address address);

        Task DeleteAddressAsync(int id);

        Task GetAddressesAsync();

        Task<Address> GetAddressByIdAsync(int id);

        Task UpdateAddressAsync(Address address);

        Task SearchForAddressesByMeasurmentAsync(DateTime startDate, DateTime endDate);

        Task SearchForAddressesByMontageAsync(DateTime startDate, DateTime endDate);

        Task SearchForAddressesByWorkersAsync(DateTime startDate, DateTime endDate, string worker);
    }
}
