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
            var addresses = await db.Addresses.AsNoTracking().ToListAsync();

            var response = new ServiceResponse<List<Address>>()
            {
                Data = addresses
            };

            return response;
        }

        public async Task<ServiceResponse<Address>> AddNewAddress(Address address)
        {
            var result = new ServiceResponse<Address>
            {
                Data = address
            };

            if (result.Data != null)
            {
                await db.Addresses.AddAsync(result.Data);

                db.SaveChanges();

                return result;
            }

            return null;
        }

        public async Task<ServiceResponse<Address>> DeleteAddress(int id)
        {
            var response = new ServiceResponse<Address>
            {
                Data = await db.Addresses.FirstOrDefaultAsync(a => a.Id == id)
            };

            if (response.Data != null)
            {
                db.Addresses.Remove(response.Data);

                db.SaveChanges();

                return response;
            }

            return null;
        }
    }
}
