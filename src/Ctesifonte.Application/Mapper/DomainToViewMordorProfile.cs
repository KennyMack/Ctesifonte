using AutoMapper;
using Ctesifonte.Application.ViewModel.Mordor;
using Ctesifonte.Domain.Mordor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.Mapper
{
    public class DomainToViewMordorProfile : Profile
    {
        public DomainToViewMordorProfile()
        {
            CreateMap<User, CreateUserVM>();
        }
    }
}
