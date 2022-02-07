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
    }
}
