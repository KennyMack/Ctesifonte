using Ctesifonte.Domain.Hefestos.Interfaces.Services;
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
        private readonly ICustomerService _ICustomerService;
        public CustomerController(ICustomerService pICustomerService)
        {
            _ICustomerService = pICustomerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ICustomerService.GetAllAsync());
        }
    }
}
