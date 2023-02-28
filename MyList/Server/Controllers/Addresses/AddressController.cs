using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyList.Server.Data;
using MyList.Server.Services.Addresses;
using MyList.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyList.Server.Controllers.Addresses
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        public ActionResult<ServiceResponse<IEnumerable<Address>>> GetAddresses()
        {
            var result = addressService.GetAddressesAsync();

            if (result == null)
            {
                return BadRequest("Something go wrong.");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Address>>> GetAddressByIdAsync(int id)
        {
            var result = await addressService.GetAddressByIdAsync(id);

            if (result == null)
            {
                return BadRequest("Something go wrong.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> AddNewAddressAsync(Address address)
        {
            var result = await addressService.AddNewAddressAsync(address);

            if (result != null)
                return Ok(result);

            return BadRequest("Something go wrong.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> DeleteAddressAsync(int id)
        {
            var response = await addressService.DeleteAddressAsync(id);

            if (response != null)
                return Ok(response);

            return BadRequest("It is not exist");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> UpdateAddressAsync(int id, Address address)
        {
            var response = await addressService.UpdateAddressAsync(id, address);

            if (response != null)
                return Ok(response);

            return NotFound("It is not exist");
        }

        [HttpGet("SearchForAddressesByMeasurment/{startDate}/{endDate}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> SearchForAddressesByMeasurmentAsync(DateTime startDate, DateTime endDate)
        {
            var response = await addressService.SearchForAddressesByMeasurmentAsync(startDate, endDate);

            if (response != null)
                return Ok(response);

            return NotFound("It Is not found.");
        }

        [HttpGet("SearchForAddressesByMontage/{startDate}/{endDate}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> SearchForAddressesByMontageAsync(DateTime startDate, DateTime endDate)
        {
            var response = await addressService.SearchForAddressesByMontageAsync(startDate, endDate);

            if (response != null)
                return Ok(response);

            return NotFound("It Is not found.");
        }

        [HttpGet("SearchForAddressesByWorkers/{startDate}/{endDate}/{worker}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> SearchForAddressesByWorkersAsync(DateTime startDate, DateTime endDate, string worker)
        {
            var response = await addressService.SearchForAddressesByWorkersAsync(startDate, endDate, worker);

            if (response != null)
                return Ok(response);

            return NotFound("It Is not found.");
        }
    }
}
