using CAP.ApplicationCore.Entity;
using CAP.Infraestructure.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.Infraestructure.Data
{
    public class CAPContext : DbContext
    {
        public CAPContext(DbContextOptions<CAPContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Matricula>().ToTable("Matricula");

            #region Configurações especificas de cada tabela
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new MatriculaMap());
            #endregion
        }
    }
}
