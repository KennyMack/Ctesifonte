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
    public class ViewToDomainHefestosProfile: Profile
    {
        public ViewToDomainHefestosProfile()
        {
            CreateMap<CreateCustomerVM, Customers>()
                .ConstructUsing(c => new Customers(c.Id, c.Name, c.CNPJ, c.Email, c.Active));
        }
    }
}
