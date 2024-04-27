using ApiDeContactos.Core.Application.Interfaces.IServicios;
using ApiDeContactos.Core.Application.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application
{
    public static class ServiceRegistrator
    {
      public static void AddApplicationLayer(this IServiceCollection service)
      {
            #region"Servicios"
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddTransient<IServicioContacto, ServicioContacto>();
            #endregion
        }
    }
}
