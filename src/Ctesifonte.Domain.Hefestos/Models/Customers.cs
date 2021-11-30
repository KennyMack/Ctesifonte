using Ctesifonte.Domain.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Hefestos.Models
{
    [Table("Customers", Schema = "Hefestos")]
    public class Customers: BaseEntity
    {
        public Customers(
            Guid Id, 
            string Name,
            string CNPJ,
            string Email)
        {
            this.Id = Id;
            this.Name = Name;
            this.CNPJ = CNPJ;
            this.Email = Email;
        }

        public Customers()
        {

        }

        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; private set; }
    }
}
