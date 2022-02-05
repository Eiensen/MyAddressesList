using Microsoft.EntityFrameworkCore;
using MyList.Server.Data;
using MyList.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyList.Server.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly DataContext db;

        public AddressService(DataContext db)
        {
            this.db = db;
        }

        public async Task<ServiceResponse<List<Address>>> GetAddressesAsync()
        {
            var response = new ServiceResponse<List<Address>>
            {
                Data = await db.Addresses.ToListAsync()
            };

            return response;
        }
    }
}
