using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Mordor.Models
{
    public class TokenResult
    {
        public string Issuer { get; }
        public string Subject { get; }
        public string Audience { get; }
        public long ExpirationTimeSeconds { get; }
        public long IssuedAtTimeSeconds { get; }
        public string Uid { get; }
        public string TenantId { get; }
        public IReadOnlyDictionary<string, object> Claims { get; }

        public string UserId { get; }
        public string Role { get; }
        public string Name { get; }
        public string Email { get; }
        
        public long AuthTime { get; }
        public bool EmailVerified { get; }

        public UserAuth UserData { get; }

        public TokenResult(FirebaseToken pToken, UserAuth pUser)
        {
            Issuer = pToken.Issuer;
            Subject = pToken.Subject;
            Audience = pToken.Audience;
            ExpirationTimeSeconds = pToken.ExpirationTimeSeconds;
            IssuedAtTimeSeconds = pToken.IssuedAtTimeSeconds;
            Uid = pToken.Uid;
            TenantId = pToken.TenantId;
            Claims = pToken.Claims;
            UserId = Claims.GetValueOrDefault("user_id", "").ToString();
            Role = Claims.GetValueOrDefault("role", "").ToString();
            Name = Claims.GetValueOrDefault("name", "").ToString();
            Email = Claims.GetValueOrDefault("email", "").ToString();
            AuthTime = Convert.ToInt64(Claims.GetValueOrDefault("auth_time", 0));
            EmailVerified = Convert.ToBoolean(Claims.GetValueOrDefault("email_verified", false));
            UserData = pUser;
        }
    }
}
