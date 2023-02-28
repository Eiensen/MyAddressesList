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

        public async Task<ServiceResponse<Address>> AddNewAddressAsync(Address address)
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

        public async Task<ServiceResponse<Address>> GetAddressByIdAsync(int id)
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

        public async Task<ServiceResponse<Address>> DeleteAddressAsync(int id)
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

        public async Task<ServiceResponse<IEnumerable<Address>>> UpdateAddressAsync(int id, Address address)
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

        public async Task<ServiceResponse<IEnumerable<Address>>> SearchForAddressesByMeasurmentAsync(DateTime startDate, DateTime endDate)
        {
            var result = await db.Addresses.Where(x => 
                    x.DateMeasurment >= startDate.Date && 
                    x.DateMeasurment <= endDate.Date.AddDays(1).Date).ToListAsync();

            if (result == null) return null;

            var response = new ServiceResponse<IEnumerable<Address>>
            {
                Data = result
            };

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Address>>> SearchForAddressesByMontageAsync(DateTime startDate, DateTime endDate)
        {
            var result = await db.Addresses.Where(x =>
                    x.DateMontage >= startDate.Date &&
                    x.DateMontage <= endDate.Date.AddDays(1).Date).ToListAsync();

            if (result == null) return null;

            var response = new ServiceResponse<IEnumerable<Address>>
            {
                Data = result
            };

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Address>>> SearchForAddressesByWorkersAsync(DateTime startDate, DateTime endDate, string worker)
        {
            var result = await db.Addresses.Where(x =>
                    x.DateMontage >= startDate.Date &&
                    x.DateMontage <= endDate.Date.AddDays(1).Date &&
                    x.WorkersName == worker).ToListAsync();

            if (result == null) return null;

            var response = new ServiceResponse<IEnumerable<Address>>
            {
                Data = result
            };

            return response;
        }
    }
}
