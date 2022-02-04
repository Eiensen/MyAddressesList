using MyList.Shared;
using System;
using System.Collections.Generic;
using UseCases;

namespace MyList.DataStore.InMemory
{
    public class AddressInMemoryRepository : IAddressRepository
    {
        private List<Address> addresses;

        public AddressInMemoryRepository()
        {
            addresses = new List<Address>()
            {
                new Address(){Id = 1, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Nova 99", Sum = 11500},
                new Address(){Id = 2, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Dobor 1", Sum = 9300},
                new Address(){Id = 3, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Znaniya 12", Sum = 8200}
            };
        }
        public IEnumerable<Address> GetAddresses()
        {
            return addresses;
        }
    }
}
