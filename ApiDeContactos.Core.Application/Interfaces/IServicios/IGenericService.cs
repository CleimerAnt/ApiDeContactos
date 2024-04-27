using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application.Interfaces.IServicios
{
    public interface IGenericService<DTO, SaveDTO, Entity> where DTO : class where SaveDTO : class where Entity : class
    {
        Task<SaveDTO> AddAsync(SaveDTO saveDTO);
        Task DeleteAsync(int Id);
        Task<List<DTO>> GetAllAsync();
        Task<SaveDTO> GetByIdAsync(int Id);
        Task UpdateAsync(SaveDTO saveDTO, int Id);
    }
}
