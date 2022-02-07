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

            return Ok(result);
        }
    }
}
