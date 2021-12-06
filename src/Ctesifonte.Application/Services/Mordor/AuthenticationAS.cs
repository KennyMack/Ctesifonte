using Ctesifonte.Application.Interfaces.Services.Mordor;
using Ctesifonte.Application.ViewModel.Mordor;
using Ctesifonte.Domain.Mordor.Interfaces.Services;
using Ctesifonte.Domain.Mordor.Models;
using Ctesifonte.Infra.Cross.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.Services.Mordor
{
    public class AuthenticationAS : IAuthenticationAS
    {
        public List<ModelException> Errors { get; set; }
        private readonly IFirebaseMordorService _IFirebaseMordorService;

        public AuthenticationAS(IFirebaseMordorService pIFirebaseMordorService)
        {
            _IFirebaseMordorService = pIFirebaseMordorService;
        }


        public Task<SignUpResult> CreateUserAsync(CreateUserVM pUser)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> SignInWithEmailAsync(SignInUserVM pUser)
        {
            try
            {
               return  await _IFirebaseMordorService.SignInWithEmailAsync(new User(pUser.Email, pUser.Password));
            }
            catch (RaException ex)
            {
                if (ex.ExceptionDetails != null)
                    Errors.Add(ex.ExceptionDetails);
                else
                    Errors.Add(new ModelException
                    {
                        ErrorCode = (int)EExceptionErrorCodes.InvalidRequest,
                        Field = "Email",
                        Messages = new[] { ex.Message },
                        Value = ""
                    });
            }
            catch (Exception ex)
            {
                Errors.Add(new ModelException
                {
                    ErrorCode = (int)EExceptionErrorCodes.InvalidRequest,
                    Field = "Email",
                    Messages = new[] { ex.Message },
                    Value = ""
                });
            }
            return null;
        }
    }
}
