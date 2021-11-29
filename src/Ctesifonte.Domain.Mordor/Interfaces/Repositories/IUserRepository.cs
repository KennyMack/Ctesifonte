using Ctesifonte.Domain.Mordor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Mordor.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(User pUser);
    }
}
