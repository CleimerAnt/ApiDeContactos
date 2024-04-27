using ApiDeContactos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application.Interfaces.IRepositorios
{
    public interface IRepositorioContacto : IGenericRepository<Contacto>
    {
    }
}
