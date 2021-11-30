using Ctesifonte.Domain.Hefestos.Interfaces.Repositories;
using Ctesifonte.Domain.Hefestos.Models;
using Ctesifonte.Infra.Repositories.Base.Repositories;
using Ctesifonte.Infra.Repositories.Hefestos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Hefestos.Repositories
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(HefestosDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
