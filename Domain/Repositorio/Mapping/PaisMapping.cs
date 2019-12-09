using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositorio.Mapping
{
    public class PaisMapping : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Foto).IsRequired().HasMaxLength(1048);

            builder.HasMany(x => x.Estados)
                .WithOne(x => x.Pais)
                .HasForeignKey(x => x.IdPais);
        }
    }
}
