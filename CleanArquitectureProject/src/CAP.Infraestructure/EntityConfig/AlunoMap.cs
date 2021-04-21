using CAP.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.Infraestructure.EntityConfig
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(al => al.Nome).IsRequired();
            builder.HasKey(al => al.AlunoId);
            
            builder.HasMany(al => al.Matriculas)
                   .WithOne(m => m.Aluno);
        }
    }
}
