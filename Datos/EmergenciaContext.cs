using System;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class EmergenciaContext : DbContext
    {
        public EmergenciaContext(DbContextOptions options):base(options)
        {
            
        } 
        public DbSet<Persona> Personas { get; set; }
    }
}