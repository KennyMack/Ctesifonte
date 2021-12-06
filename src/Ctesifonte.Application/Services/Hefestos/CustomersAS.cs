using AutoMapper;
using Ctesifonte.Application.Interfaces.Services.Hefestos;
using Ctesifonte.Application.ViewModel.Hefestos;
using Ctesifonte.Domain.Base.Interfaces.Services;
using Ctesifonte.Domain.Hefestos.Interfaces.Services;
using Ctesifonte.Domain.Hefestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.Services.Hefestos
{
    public class CustomersAS : BaseAppService<Customers>, ICustomersAS
    {
        private readonly IMapper _IMapper;
        private readonly ICustomerService _ICustomerService;

        public CustomersAS(IMapper IMapper,
            ICustomerService ICustomerService) : base(IMapper, ICustomerService)
        {
            _IMapper = IMapper;
            _ICustomerService = ICustomerService;
        }

        public async Task<CreateCustomerVM> CreateAsync(CreateCustomerVM pCreateCustomerVM)
        {
            this.Errors.Clear();
            var Customer = _ICustomerService.Add(_IMapper.Map<Customers>(pCreateCustomerVM));

            if (Errors.Any())
            {
                _ICustomerService.RollBackChanges();
                return pCreateCustomerVM;
            }

            await _ICustomerService.SaveChangesAsync();

            if (Errors.Any())
            {
                _ICustomerService.RollBackChanges();
                return pCreateCustomerVM;
            }

            return _IMapper.Map<CreateCustomerVM>(Customer);

        }
    }
}
