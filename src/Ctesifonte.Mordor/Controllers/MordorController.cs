using Ctesifonte.Domain.Mordor.Interfaces.Services;
using Ctesifonte.Domain.Mordor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ctesifonte.Mordor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MordorController : ControllerBase
    {
        private readonly IFirebaseMordorProvider _IFirebaseMordorProvider;

        public MordorController(IFirebaseMordorProvider pIFirebaseMordorProvider)
        {
            _IFirebaseMordorProvider = pIFirebaseMordorProvider;
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> PostSignInUser(User userModel)
        {
            try
            {
                var result = await _IFirebaseMordorProvider.SignInWithEmailAsync(userModel);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> PostSignOn(User userModel)
        {
            try
            {
                var createdUser = await _IFirebaseMordorProvider.SignUpAsync(userModel);

                return Ok(createdUser);
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}\r\n{ex.InnerException?.Message}");
            }
        }
    }
}
