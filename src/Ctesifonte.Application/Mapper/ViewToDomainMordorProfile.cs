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
    public class ViewToDomainMordorProfile : Profile
    {
        public ViewToDomainMordorProfile()
        {
            CreateMap<CreateUserVM, User>()
                .ConstructUsing(c => new User(c.Id, c.Uid, c.Username, c.Email, c.Password, c.Role, c.Active));
        }
    }
}
