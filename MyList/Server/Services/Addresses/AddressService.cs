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

        public ServiceResponse<IEnumerable<Address>> GetAddressesAsync()
        {
            var addresses = db.Addresses.ToList();

            var response = new ServiceResponse<IEnumerable<Address>>()
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
                db.Addresses.Add(result.Data);

                await db.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<ServiceResponse<Address>> GetAddressById(int id)
        {
            var request = await db.Addresses.FindAsync(id);

            var result = new ServiceResponse<Address>
            {
                Data = request
            };

            if (result.Data != null)
            {   
                return result;
            }

            return null;
        }

        public async Task<ServiceResponse<Address>> DeleteAddress(int id)
        {
            var result = await db.Addresses.FindAsync(id);

            if (result != null)
            {
                var response = new ServiceResponse<Address>
                {
                    Data = result
                };

                db.Addresses.Remove(result);

                db.SaveChanges();

                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<ServiceResponse<IEnumerable<Address>>> UpdateAddress(int id, Address address)
        {
            var result = await db.Addresses.FirstOrDefaultAsync(a => a.Id == id);

            if (result != null)
            {  
                result.Name = address.Name;
                result.WorkersName = address.WorkersName;
                result.DateMeasurment = address.DateMeasurment;
                result.DateMontage = address.DateMontage;
                result.Sum = address.Sum;

                await db.SaveChangesAsync();                            

                return GetAddressesAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
