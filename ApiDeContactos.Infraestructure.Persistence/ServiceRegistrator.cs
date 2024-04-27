using ApiDeContactos.Core.Application.Interfaces.IRepositorios;
using ApiDeContactos.Infraestructure.Persistence.Context;
using ApiDeContactos.Infraestructure.Persistence.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Infraestructure.Persistence
{
    public static class ServiceRegistrator
    {
        public static void AddPersistenceLayer(this IServiceCollection service, IConfiguration configuration)
        {
            #region"AddContext"
            service.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("conexion"), m =>
                m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });
            #endregion

            #region"Servicios"
            service.AddTransient(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            service.AddTransient<IRepositorioContacto, RepositorioContacto>();
            #endregion
        }
    }
}
