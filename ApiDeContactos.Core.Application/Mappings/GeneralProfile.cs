using ApiDeContactos.Core.Application.DTOS.ContactoDTO;
using ApiDeContactos.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Contacto, ContactoDTO>().ReverseMap();
            CreateMap<Contacto, SaveContactoDTO>().ReverseMap();
        }
    }
}
