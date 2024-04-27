using ApiDeContactos.Core.Application.DTOS.ContactoDTO;
using ApiDeContactos.Core.Application.Interfaces.IServicios;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeContactos.Controllers.V1
{
    public class ContactosController : BaseApiController
    {
        private readonly IServicioContacto _servicioContacto;
        public ContactosController(IServicioContacto servicioContacto)
        {
            _servicioContacto = servicioContacto;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AgregarContacto(SaveContactoDTO SaveDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (SaveDTO == null) return BadRequest();

                bool confirmarContacto = await _servicioContacto.ConfirmarContacto(SaveDTO.Nombre);

                if (confirmarContacto == true) return BadRequest();

                await _servicioContacto.AddAsync(SaveDTO);

                return CreatedAtAction(nameof(AgregarContacto), new { id = SaveDTO.Id, SaveDTO });
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactoDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListaContactos()
        {
            try
            {
                var contactos = await _servicioContacto.GetAllAsync();

                if(contactos == null || contactos.Count == 0)
                {
                    return NoContent();
                }

                return Ok(contactos);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            } 
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactoDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListaContactosPorId(int Id)
        {
            try
            {
                var contactos = await _servicioContacto.GetByIdAsync(Id);

                if (contactos == null)
                {
                    return NoContent();
                }

                return Ok(contactos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminarContacto(int Id)
        {
            try
            {
                if(Id == 0)
                {
                    return BadRequest();
                }

                var confirmarContacto = await _servicioContacto.GetByIdAsync(Id);

                if(confirmarContacto == null)
                {
                    ModelState.AddModelError("Contacto no Encontrado", "Ha ingresado un Id no registrado");
                    return BadRequest(ModelState);    
                }

                await _servicioContacto.DeleteAsync(Id);    

                return Ok();    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactoDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarContacto(SaveContactoDTO saveDto, int Id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var confirmarContacto = await _servicioContacto.GetByIdAsync(Id);

                if (confirmarContacto == null)
                {
                    ModelState.AddModelError("Contacto no Encontrado", "Ha ingresado un Id no registrado");
                    return BadRequest(ModelState);
                }

                saveDto.Id = Id;
                await _servicioContacto.UpdateAsync(saveDto, Id);

                return Ok(saveDto);    

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
