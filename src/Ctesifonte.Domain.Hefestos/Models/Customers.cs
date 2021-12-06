using Ctesifonte.Domain.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Hefestos.Models
{
    public class Customers: BaseEntity
    {
        public Customers(
            Guid Id, 
            string Name,
            string CNPJ,
            string Email,
            bool Active)
        {
            this.Id = Id;
            this.Name = Name;
            this.CNPJ = CNPJ;
            this.Email = Email;
            this.Active = Active;
        }

        public Customers()
        {

        }

        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
    }
}
