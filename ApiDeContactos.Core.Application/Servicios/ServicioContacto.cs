using ApiDeContactos.Core.Application.DTOS.ContactoDTO;
using ApiDeContactos.Core.Application.Interfaces.IRepositorios;
using ApiDeContactos.Core.Application.Interfaces.IServicios;
using ApiDeContactos.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application.Servicios
{
    public class ServicioContacto: GenericService<ContactoDTO, SaveContactoDTO, Contacto>, IServicioContacto
    {
        private readonly IRepositorioContacto _repository;
        private readonly IMapper _mapper;
        public ServicioContacto(IRepositorioContacto repositorioContacto, IMapper mapper) : base(repositorioContacto, mapper)
        {
            _repository = repositorioContacto;
            _mapper = mapper;
        }

        public async Task<bool> ConfirmarContacto(string nombre)
        {
            var contactos = await _repository.GetAllAsync();

            var confirmar = contactos.FirstOrDefault(c => c.Nombre == nombre);
            
            if (confirmar != null) { return true; } else return false;
        }
    }
}
