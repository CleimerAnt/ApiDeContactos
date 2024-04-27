using ApiDeContactos.Core.Application.Interfaces.IRepositorios;
using ApiDeContactos.Core.Domain.Entities;
using ApiDeContactos.Infraestructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Infraestructure.Persistence.Repositorios
{
    public class RepositorioContacto : GenericRepository<Contacto>, IRepositorioContacto
    {
        private readonly ApplicationContext _Context;
        public RepositorioContacto(ApplicationContext context) :base(context)
        {
            _Context = context;
        }
    }
}
