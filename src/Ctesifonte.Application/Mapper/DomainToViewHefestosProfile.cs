using AutoMapper;
using Ctesifonte.Application.ViewModel.Hefestos;
using Ctesifonte.Domain.Hefestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.Mapper
{
    public class DomainToViewHefestosProfile : Profile
    {
        public DomainToViewHefestosProfile()
        {
            CreateMap<Customers, CreateCustomerVM>();
        }
    }
}
