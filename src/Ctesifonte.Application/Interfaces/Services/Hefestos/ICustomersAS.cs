using Ctesifonte.Application.ViewModel.Hefestos;
using Ctesifonte.Domain.Hefestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.Interfaces.Services.Hefestos
{
    public interface ICustomersAS : IBaseAppService<Customers>
    {
        Task<CreateCustomerVM> CreateAsync(CreateCustomerVM pCreateCustomerVM);
    }
}
