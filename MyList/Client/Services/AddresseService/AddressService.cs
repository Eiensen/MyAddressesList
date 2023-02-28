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

        public async Task GetAddressesAsync()
        {
            var result = await http.GetFromJsonAsync<ServiceResponse<List<Address>>>("api/address");

            if (result != null && result.Data != null)
            {
                Addresses = result.Data;
            }
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var result = await http.GetFromJsonAsync<ServiceResponse<Address>>($"api/address/{id}");

            if (result != null && result.Data != null)
            {
                var response = Addresses.FirstOrDefault(a => a.Id == result.Data.Id);

                if (response == null) return null;

                return response;
            }

            return null;
        }

        public async Task AddNewAddressAsync(Address address)
        {
            var request = await http.PostAsJsonAsync("api/address", address);

            var result = await request.Content.ReadFromJsonAsync<ServiceResponse<Address>>();

            Addresses.Add(result.Data);
        }

        public async Task DeleteAddressAsync(int id)
        {
            var request = await http.DeleteAsync($"api/address/{id}");

            var result = await request.Content.ReadFromJsonAsync<ServiceResponse<Address>>();

            Addresses.Remove(result.Data);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            var request = await http.PutAsJsonAsync($"api/address/{address.Id}", address);

            var result = await request.Content.ReadFromJsonAsync<ServiceResponse<List<Address>>>();

            Addresses = result.Data;
        }

        public async Task SearchForAddressesByMeasurmentAsync(DateTime startDate, DateTime endDate)
        {
            var result = await http.GetFromJsonAsync<ServiceResponse<List<Address>>>
                ("api/address/SearchForAddressesByMeasurment/" +
                $"{startDate.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}" +
                $"/{endDate.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}");

            if (result != null && result.Data != null)
            {
                Addresses = result.Data;
            }
        }

        public async Task SearchForAddressesByMontageAsync(DateTime startDate, DateTime endDate)
        {
            var result = await http.GetFromJsonAsync<ServiceResponse<List<Address>>>
                ("api/address/SearchForAddressesByMontage/" +
                $"{startDate.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}" +
                $"/{endDate.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}");

            if (result != null && result.Data != null)
            {
                Addresses = result.Data;
            }
        }

        public async Task SearchForAddressesByWorkersAsync(DateTime startDate, DateTime endDate, string worker)
        {
            var result = await http.GetFromJsonAsync<ServiceResponse<List<Address>>>
                ("api/address/SearchForAddressesByWorkers/" +
                $"{startDate.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}" +
                $"/{endDate.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)}" +
                $"/{worker}");

            if (result != null && result.Data != null)
            {
                Addresses = result.Data;
            }
        }
    }
}
