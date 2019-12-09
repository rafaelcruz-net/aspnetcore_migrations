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
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Pais { get; set; }

        public string connectionString = "Server=tcp:infnetassesmentdb.database.windows.net,1433;Initial Catalog=infnetassesment;Persist Security Info=False;User ID=infnetassesmentusr;Password=123456789#A;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaisMapping());
            modelBuilder.ApplyConfiguration(new EstadoMapping());
        }
        



    }
}
