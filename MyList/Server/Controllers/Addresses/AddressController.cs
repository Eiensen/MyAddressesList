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
        public async Task<ActionResult<ServiceResponse<List<Address>>>> GetAddresses()
        {
            var result = await addressService.GetAddressesAsync();

            if (result == null)
            {
                return BadRequest("Something go wrong.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Address>>>> AddNewAddress(Address address)
        {
            var result = await addressService.AddNewAddress(address);

            if (result == null)
            {
                return BadRequest("Something go wrong.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = await addressService.DeleteAddress(id);

            if (result == null)
            {
                return BadRequest("Not found address to delete.");
            }

            return Ok(result);
        }
    }
}
