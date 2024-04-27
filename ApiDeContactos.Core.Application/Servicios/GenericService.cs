using ApiDeContactos.Core.Application.Interfaces.IRepositorios;
using ApiDeContactos.Core.Application.Interfaces.IServicios;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Core.Application.Servicios
{
    public class GenericService<DTO, SaveDTO, Entity> : IGenericService<DTO, SaveDTO, Entity>  where DTO : class where SaveDTO : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<SaveDTO> AddAsync(SaveDTO saveDTO)
        {
            Entity entity = _mapper.Map<Entity>(saveDTO);

            await _repository.AddAsync(entity);

            return saveDTO;
        }

        public async Task<List<DTO>> GetAllAsync()
        {
            var listaDatos = await _repository.GetAllAsync();

            return _mapper.Map<List<DTO>>(listaDatos);
        }
        public async Task<SaveDTO> GetByIdAsync(int Id)
        {
            Entity entity = await _repository.GetByIdAsync(Id);

            SaveDTO saveDto = _mapper.Map<SaveDTO>(entity);

            return saveDto;
        }

        public async Task DeleteAsync(int Id)
        {
            Entity entity = await _repository.GetByIdAsync(Id);
            await _repository.DeleteAsync(entity);
        }

        public async Task UpdateAsync(SaveDTO saveDTO, int Id)
        {
            Entity entity = _mapper.Map<Entity>(saveDTO);

            await _repository.UpdateAsync(entity, Id);
        }
    }
}
