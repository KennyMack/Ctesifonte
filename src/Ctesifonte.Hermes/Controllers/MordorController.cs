using Ctesifonte.Domain.Mordor.Interfaces.Services;
using Ctesifonte.Domain.Mordor.Models;
using Firebase.Auth;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FirebaseAuth = FirebaseAdmin.Auth.FirebaseAuth;
using User = Ctesifonte.Domain.Mordor.Models.User;

namespace Ctesifonte.Hermes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MordorController : ControllerBase
    {
        private readonly IFirebaseMordorProvider _IFirebaseMordorProvider;
        private readonly IConfiguration configuration;

        public MordorController(IConfiguration configuration,
            IFirebaseMordorProvider pIFirebaseMordorProvider
            )
        {
            _IFirebaseMordorProvider = pIFirebaseMordorProvider;
            this.configuration = configuration;
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

                return BadRequest(ex.Message);
            }
        }


        /*private readonly IFirebaseAuthProvider _IFirebaseAuthProvider;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;

        public MordorController(IConfiguration configuration, 
            ITokenService tokenService
            )
        {
            _IFirebaseAuthProvider = new FirebaseAuthProvider(
              new FirebaseConfig("AIzaSyC1fJyLU2YZZkTze8RJNoDebbfGCcT-KT0"));
            this.configuration = configuration;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("sign-in")]
        public IActionResult Post(User userModel)
        {
            return Ok(tokenService.BuildToken(configuration["Jwt:MordorSSO:Key"], configuration["Jwt:MordorSSO:ValidIssuer"], userModel));
        }

        [HttpPost]
        [Route("sign-user")]
        public async Task<IActionResult> PostSignInUser(User userModel)
        {
            //log in the user
            var fbAuthLink = await _IFirebaseAuthProvider
                            .SignInWithEmailAndPasswordAsync(userModel.Email, userModel.Password);

            string token = fbAuthLink.FirebaseToken;
            var user = await FirebaseAuth.DefaultInstance.GetUserAsync(fbAuthLink.User.LocalId);

            //saving the token in a session variable
            if (token != null)
            {
                // HttpContext.Session.SetString("_UserToken", token);

                return Ok(new {
                    fbAuthLink = fbAuthLink,
                    user = user
                });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("me")]
        public IActionResult GetMe()
        {
            return Ok(new
            {
                name = User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value,
                // email = User.Claims.Where(x => x.Type == "email").FirstOrDefault().Value,
                picture = User.Claims.Where(x => x.Type == "email").FirstOrDefault().Value,
            });
        }


        [HttpPost]
        [Route("sign-on")]
        public async Task<IActionResult> PostSignOn(User userModel)
        {
            try
            {
                var claims = new Dictionary<string, object>
                {
                    { "Role", "Administrator" }
                };

                UserRecord createdUser = await FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs
                {
                    Email = userModel.Email,
                    EmailVerified = true,
                    Password = userModel.Password,
                    DisplayName = userModel.Username,
                    Disabled = false
                });
                await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(createdUser.Uid, claims);

                return Ok(createdUser);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }*/
    }
}
