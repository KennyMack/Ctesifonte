using Ctesifonte.Domain.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Mordor.Models
{
    public class User : BaseEntity
    {
        public string Uid { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool Active { get; private set; }

        public User()
        {

        }

        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;

        }

        public User(
            Guid Id,
            string Uid,
            string Username,
            string Email,
            string Password,
            string Role,
            bool Active)
        {
            this.Id = Id;
            this.Uid = Uid;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.Role = Role;
            this.Active = Active;
        }
    }
}
