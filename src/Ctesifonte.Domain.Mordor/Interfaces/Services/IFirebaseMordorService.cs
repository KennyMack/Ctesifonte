using Ctesifonte.Domain.Mordor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Mordor.Interfaces.Services
{
    public interface IFirebaseMordorService
    {
        Task<SignInResult> SignInWithEmailAsync(User pUser);
        Task<SignUpResult> SignUpAsync(User pUser);
        Task<UserAuth> GetUserByUid(string pUid);
        Task<TokenResult> VerifyTokenAsync(string pToken);
        
    }
}
