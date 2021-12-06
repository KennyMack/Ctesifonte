using Ctesifonte.Domain.Mordor.Interfaces.Repositories;
using Ctesifonte.Domain.Mordor.Models;
using Ctesifonte.Infra.Repositories.Mordor.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Mordor.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IConfiguration Configuration;

        public UserRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public User Create(User pUser)
        {
            using (var context = new MordorDbContext(Configuration))
            {
                context.Users.Add(pUser);
                context.SaveChanges();
            }
            return pUser;
        }
    }
}
