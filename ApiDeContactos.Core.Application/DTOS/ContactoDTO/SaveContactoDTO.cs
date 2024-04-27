using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application.DTOS.ContactoDTO
{
    public class SaveContactoDTO
    {
        [Required(ErrorMessage = "El Nombre del Contacto es Requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Telefono del Contacto es Requerido")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La Direccion del Contacto es Requerido")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Es Requerido una Descripcion del Contacto")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Es Requerida una Imagen del Contacto")]
        [DataType(DataType.Text)]
        public string ImgUrl { get; set; }
    }
}
