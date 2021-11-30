using Ctesifonte.Domain.Mordor.Interfaces.Services;
using Ctesifonte.Domain.Mordor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ctesifonte.Mordor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MordorController : ControllerBase
    {
        private readonly IFirebaseMordorService _IFirebaseMordorProvider;

        public MordorController(IFirebaseMordorService pIFirebaseMordorProvider)
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

        [HttpGet]
        [Route("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var TokenRequest = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer", "").Trim();

            var decoded = await _IFirebaseMordorProvider.VerifyTokenAsync(TokenRequest);

            return Ok(decoded);
        }
    }
}
