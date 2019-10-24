using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_DAL.Repositories;
using Project_DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.ServiceCollectionConfig
{
    public static class RegisterDataAccessLayerTypes
    {
        public static void RegisterDataAccessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IAdvertRepository, AdvertRepository>();
            serviceCollection.AddScoped<IAdvertUserRepository, AdvertUserRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            //TODO:Needs to be reviewed
            serviceCollection.AddDbContext<ProjectContext>(opts => opts.UseSqlServer(configuration["ConnectionString:ProjectDatabase"], x => x.MigrationsAssembly("Project_DAL")), ServiceLifetime.Scoped);
        }
    }
}
