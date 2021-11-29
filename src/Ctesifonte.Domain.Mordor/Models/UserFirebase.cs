using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Mordor.Models
{
    public class UserAuth
    {
        public UserAuth(
            string Uid,
            string DisplayName,
            string Email,
            string PhoneNumber,
            string PhotoUrl,
            string ProviderId,
            bool EmailVerified,
            bool Disabled,
            DateTime TokensValidAfterTimestamp,
            IReadOnlyDictionary<string, object> CustomClaims,
            string TenantId
            )
        {
            this.Uid = Uid;
            this.DisplayName = DisplayName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.PhotoUrl = PhotoUrl;
            this.ProviderId = ProviderId;
            this.EmailVerified = EmailVerified;
            this.Disabled = Disabled;
            this.TokensValidAfterTimestamp = TokensValidAfterTimestamp;
            this.CustomClaims = CustomClaims;
            this.TenantId = TenantId;
        }

        public string Uid { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string PhotoUrl { get; }
        public string ProviderId { get; }
        public bool EmailVerified { get; }
        public bool Disabled { get; }
        public DateTime TokensValidAfterTimestamp { get; }
        public IReadOnlyDictionary<string, object> CustomClaims { get; }
        public string TenantId { get; }
    }
}
