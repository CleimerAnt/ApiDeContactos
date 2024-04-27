﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Domain.Entities
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion {  get; set; }  
        public string Descripcion { get; set; } 
        public string ImgUrl { get; set; }  
    }
}
