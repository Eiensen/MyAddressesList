using MyList.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyList.Client.Services.AddresseService
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient http;

        public AddressService(HttpClient http)
        {
            this.http = http;
        }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public async Task GetAddresses()
        {
            var result = await http.GetFromJsonAsync<ServiceResponse<List<Address>>>("api/address");

            if (result != null && result.Data != null)
                Addresses = result.Data;
        }

        public async Task AddAddress(Address address)
        {
            var request = new ServiceResponse<Address>
            {
                Data = address
            };

            var result = await http.PostAsJsonAsync("api/address", request);

            if (result != null && result.IsSuccessStatusCode)
                Addresses.Add(address);
        }

        //public async Task DeleteAddress(int addressId)
        //{
        //    var addressToDelete = await 
        //}
    }
}
