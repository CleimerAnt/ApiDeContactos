using ApiDeContactos.Core.Application.DTOS.ContactoDTO;
using ApiDeContactos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application.Interfaces.IServicios
{
    public interface IServicioContacto : IGenericService<ContactoDTO, SaveContactoDTO, Contacto>
    {
        Task<bool> ConfirmarContacto(string nombre);
    }
}
