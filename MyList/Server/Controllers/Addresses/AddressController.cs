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
        public async Task<ActionResult<ServiceResponse<Address>>> GetAddressById(int id)
        {
            var result = await addressService.GetAddressById(id);

            if (result == null)
            {
                return BadRequest("Something go wrong.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> AddNewAddress(Address address)
        {
            var result = await addressService.AddNewAddress(address);

            if (result != null)
                return Ok(result);

            return BadRequest("Something go wrong.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> DeleteAddress(int id)
        {
            var response = await addressService.DeleteAddress(id);

            if (response != null)
                return Ok(response);

            return BadRequest("It is not exist");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> UpdateAddress(int id, Address address)
        {
            var response = await addressService.UpdateAddress(id, address);

            if (response != null)
                return Ok(response);

            return NotFound("It is not exist");
        }

        [HttpGet("SearchForAddressesByMeasurment/{startDate}/{endDate}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> SearchForAddressesByMeasurment(DateTime startDate, DateTime endDate)
        {
            var response = await addressService.SearchForAddressesByMeasurment(startDate, endDate);

            if (response != null)
                return Ok(response);

            return NotFound("It Is not found.");
        }

        [HttpGet("SearchForAddressesByMontage/{startDate}/{endDate}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> SearchForAddressesByMontage(DateTime startDate, DateTime endDate)
        {
            var response = await addressService.SearchForAddressesByMontage(startDate, endDate);

            if (response != null)
                return Ok(response);

            return NotFound("It Is not found.");
        }

        [HttpGet("SearchForAddressesByWorkers/{startDate}/{endDate}/{worker}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Address>>>> SearchForAddressesByWorkers(DateTime startDate, DateTime endDate, string worker)
        {
            var response = await addressService.SearchForAddressesByWorkers(startDate, endDate, worker);

            if (response != null)
                return Ok(response);

            return NotFound("It Is not found.");
        }
    }
}
