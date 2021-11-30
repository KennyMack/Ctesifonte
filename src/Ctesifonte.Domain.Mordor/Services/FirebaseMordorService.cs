using Ctesifonte.Domain.Mordor.Interfaces.Repositories;
using Ctesifonte.Domain.Mordor.Interfaces.Services;
using Ctesifonte.Domain.Mordor.Models;
using Firebase.Auth;
using FirebaseAdmin.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAuth = FirebaseAdmin.Auth.FirebaseAuth;
using User = Ctesifonte.Domain.Mordor.Models.User;

namespace Ctesifonte.Domain.Mordor.Services
{
    public class FirebaseMordorService : IFirebaseMordorService
    {
        private readonly IConfiguration _IConfiguration;
        private readonly IUserRepository _IUserRepository;
        private readonly FirebaseAuth _FirebaseAuth;
        private string ApiKey { get; }
        private readonly IFirebaseAuthProvider _IFirebaseAuthProvider;

        public FirebaseMordorService(IConfiguration pConfiguration,
            IUserRepository pIUserRepository)
        {
            _IConfiguration = pConfiguration;
            _IUserRepository = pIUserRepository;
            ApiKey = _IConfiguration["Jwt:Firebase:ApiKey"];
            _FirebaseAuth = FirebaseAuth.DefaultInstance;
            _IFirebaseAuthProvider = new FirebaseAuthProvider(
              new FirebaseConfig(ApiKey));
        }

        public async Task<SignInResult> SignInWithEmailAsync(User pUser)
        {
            var fbAuthLink = await _IFirebaseAuthProvider
                            .SignInWithEmailAndPasswordAsync(pUser.Email, pUser.Password);

            if (fbAuthLink.FirebaseToken == null)
                throw new Exception("Login inválido");

            var user = await FirebaseAuth.DefaultInstance.GetUserAsync(fbAuthLink.User.LocalId);

            return new SignInResult(user, fbAuthLink);
        }

        public async Task<SignUpResult> SignUpAsync(User pUser)
        {
            var claims = new Dictionary<string, object>
            {
                { "role", pUser.Role }
            };

            UserRecord createdUser = await _FirebaseAuth.CreateUserAsync(new UserRecordArgs
            {
                Email = pUser.Email,
                EmailVerified = true,
                Password = pUser.Password,
                DisplayName = pUser.Username,
                Disabled = false
            });
            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(createdUser.Uid, claims);
            
            var user = await GetUserByUid(createdUser.Uid);

            _IUserRepository.Create(pUser);

            return new SignUpResult(user);
        }

        public async Task<TokenResult> VerifyTokenAsync(string pToken)
        {
            var decoded = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(pToken);
            var user = await GetUserByUid(decoded.Uid);
            return new TokenResult(decoded, user);
        }

        public async Task<UserAuth> GetUserByUid(string pUid)
        {
            var user = await FirebaseAuth.DefaultInstance.GetUserAsync(pUid);

            return new UserAuth(
                user.Uid,
                user.DisplayName,
                user.Email,
                user.PhoneNumber,
                user.PhotoUrl,
                user.ProviderId,
                user.EmailVerified,
                user.Disabled,
                user.TokensValidAfterTimestamp,
                user.CustomClaims,
                user.TenantId);
        }
    }
}
