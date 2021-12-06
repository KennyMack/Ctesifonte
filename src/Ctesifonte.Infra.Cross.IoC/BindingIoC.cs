using Ctesifonte.Application.Interfaces.Services.Hefestos;
using Ctesifonte.Application.Interfaces.Services.Mordor;
using Ctesifonte.Application.Services.Hefestos;
using Ctesifonte.Application.Services.Mordor;
using Ctesifonte.Domain.Hefestos.Interfaces.Repositories;
using Ctesifonte.Domain.Hefestos.Interfaces.Services;
using Ctesifonte.Domain.Hefestos.Services;
using Ctesifonte.Domain.Mordor.Interfaces.Repositories;
using Ctesifonte.Domain.Mordor.Interfaces.Services;
using Ctesifonte.Domain.Mordor.Services;
using Ctesifonte.Infra.Repositories.Hefestos.Context;
using Ctesifonte.Infra.Repositories.Hefestos.Repositories;
using Ctesifonte.Infra.Repositories.Mordor.Context;
using Ctesifonte.Infra.Repositories.Mordor.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ctesifonte.Infra.Cross.IoC
{
    public static class BindingIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IFirebaseMordorService, FirebaseMordorService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IAuthenticationAS, AuthenticationAS>();
            services.AddScoped<ICustomersAS, CustomersAS>();

            services.AddDbContext<MordorDbContext>();
            services.AddDbContext<HefestosDbContext>();
        }

    }
}
