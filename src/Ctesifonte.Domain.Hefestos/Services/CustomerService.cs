using Ctesifonte.Domain.Base.Interfaces.Repositories;
using Ctesifonte.Domain.Base.Interfaces.Services;
using Ctesifonte.Domain.Base.Services;
using Ctesifonte.Domain.Hefestos.Interfaces.Repositories;
using Ctesifonte.Domain.Hefestos.Interfaces.Services;
using Ctesifonte.Domain.Hefestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Hefestos.Services
{
    public class CustomerService : BaseService<Customers>, ICustomerService
    {
        public CustomerService(ICustomerRepository repo) : base(repo)
        {
        }
    }
}
