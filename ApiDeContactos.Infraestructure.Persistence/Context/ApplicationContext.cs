using ApiDeContactos.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeContactos.Infraestructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions context) : base(context)
        {
            
        }
        public DbSet<Contacto> contactos { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Tabla"
            modelBuilder.Entity<Contacto>().ToTable("Contactos");
            modelBuilder.Entity<Contacto>().HasKey(c => c.Id);  
            #endregion

        }
    }
}
