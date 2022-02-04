using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private List<Address> addresses = new List<Address>()
            {
                new Address(){Id = 1, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Nova 99", Sum = 11500, WorkersName = Worker.Александр},
                new Address(){Id = 2, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Dobor 1", Sum = 9300, WorkersName = Worker.Броня},
                new Address(){Id = 3, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Znaniya 12", Sum = 8200, WorkersName = Worker.Дима}
            };
        
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAddresses()
        {
            return Ok(addresses);
        }
    }
}
