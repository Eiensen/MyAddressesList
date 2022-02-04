using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyList.Server.Data;
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
        private readonly DataContext db;

        public AddressController(DataContext db)
        {
            this.db = db;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAddresses()
        {
            var addresses = await db.Addresses.ToListAsync();

            return Ok(addresses);
        }
    }
}
