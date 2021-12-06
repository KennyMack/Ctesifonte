using Ctesifonte.Application.ViewModel.Mordor;
using Ctesifonte.Domain.Mordor.Models;
using Ctesifonte.Infra.Cross.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.Interfaces.Services.Mordor
{
    public interface IAuthenticationAS
    {
        List<ModelException> Errors { get; set; }
        Task<SignInResult> SignInWithEmailAsync(SignInUserVM pUser);
        Task<SignUpResult> CreateUserAsync(CreateUserVM pUser);
    }
}
