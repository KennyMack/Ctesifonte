using Firebase.Auth;
using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Mordor.Models
{
    public class SignInResult
    {
        public string Token { get; }
        public string RefreshToken { get; }
        public int ExpiresIn { get; }
        public bool IsExpired { get; }
        public DateTime Created { get; }

        public UserAuth UserFirebase { get; }

        public SignInResult(UserRecord pUserRecord, FirebaseAuthLink pAuthLink)
        {
            UserFirebase = new UserAuth(
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
            Token = pAuthLink.FirebaseToken;
            RefreshToken = pAuthLink.RefreshToken;
            ExpiresIn = pAuthLink.ExpiresIn;
            IsExpired = pAuthLink.IsExpired();
            Created = pAuthLink.Created;
            
        }
    }
}
