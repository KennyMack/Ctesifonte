using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Mordor.Models
{
    public class SignUpResult
    {
        public UserAuth UserData { get; }

        public SignUpResult(UserAuth pUserAuth)
        {
            UserData = pUserAuth;
        }

        public SignUpResult(UserRecord pUserRecord)
        {
            UserData = new UserAuth(
                pUserRecord.Uid,
                pUserRecord.DisplayName,
                pUserRecord.Email,
                pUserRecord.PhoneNumber,
                pUserRecord.PhotoUrl,
                pUserRecord.ProviderId,
                pUserRecord.EmailVerified,
                pUserRecord.Disabled,
                pUserRecord.TokensValidAfterTimestamp,
                pUserRecord.CustomClaims,
                pUserRecord.TenantId
            );
        }
    }
}
