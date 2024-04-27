using ApiDeContactos.Core.Application.Interfaces.IRepositorios;
using ApiDeContactos.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace ApiDeContactos.Infraestructure.Persistence.Repositorios
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Entity> AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Entity>> GetAllAsync() => await _context.Set<Entity>().ToListAsync();

        public async Task<Entity> GetByIdAsync(int Id) => await _context.Set<Entity>().FindAsync(Id);

        public async Task DeleteAsync(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entity entity, int Id)
        {
            Entity entry = await _context.Set<Entity>().FindAsync(Id);

            _context.Entry(entry).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }

    }
}
