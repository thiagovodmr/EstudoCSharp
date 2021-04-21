using CAP.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.Infraestructure.EntityConfig
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.Property(al => al.Titulo).IsRequired();

            builder.HasKey(c => c.CursoId);
            builder.HasMany(al => al.Matriculas)
                   .WithOne(m => m.Curso);


        }
    }
}
