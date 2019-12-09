using Domain.Repositorio.Mapping;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositorio
{
    public class AssesmentContext : DbContext
    {
        DbSet<Estado> Estados { get; set; }
        DbSet<Pais> Pais { get; set; }

        public AssesmentContext(DbContextOptions options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisMapping());
            modelBuilder.ApplyConfiguration(new EstadoMapping());
        }
        



    }
}
