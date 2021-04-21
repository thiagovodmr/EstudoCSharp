using CAP.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.Infraestructure.EntityConfig
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(m => m.MatriculaId);
          
            builder.Property(m => m.DataInicio).IsRequired();
            builder.Property(m => m.DataFim).IsRequired();
            
            builder.HasOne(m => m.Aluno)
                   .WithMany(m => m.Matriculas)
                   .HasForeignKey(m => m.AlunoId);
            
            builder.HasOne(m => m.Curso)
                   .WithMany(m => m.Matriculas)
                   .HasForeignKey(m => m.CursoId);

            //builder.HasAlternateKey(m => new { m.AlunoId, m.DataInicio, m.DataFim });
            builder.HasIndex(m => new { m.AlunoId, m.DataInicio, m.DataFim, m.Turno })
                    .IsUnique();
        }
    }
}
