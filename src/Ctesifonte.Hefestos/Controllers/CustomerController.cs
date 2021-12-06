using Ctesifonte.Application.Interfaces.Services.Hefestos;
using Ctesifonte.Application.ViewModel.Hefestos;
using Ctesifonte.Domain.Hefestos.Interfaces.Services;
using Ctesifonte.Domain.Hefestos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ctesifonte.Hefestos.Controllers
{
    [Route("api/business/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersAS _ICustomersAS;
        public CustomerController(
            ICustomersAS pICustomersAS)
        {
            _ICustomersAS = pICustomersAS;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]CreateCustomerVM Customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _ICustomersAS.CreateAsync(Customer);

            if (_ICustomersAS.Errors.Any())
                return BadRequest(ModelState);

            return Ok(Customer);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ICustomersAS.GetAllAsync());
        }
    }
}
