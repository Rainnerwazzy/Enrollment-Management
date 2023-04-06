using System;
using Enrollment.Management.Courses.Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enrollment.Management.Courses.Infrastructure.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cursos> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("CURSOS");

                entity.Property(e => e.Id).HasColumnName("CURSO_ID");

                entity.Property(e => e.Custo)
                    .HasColumnName("CUSTO")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DataLimiteMatricula)
                    .HasColumnName("DATA_LIMITE_MATRICULA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Disciplina).HasColumnName("DISCIPLINA");

                entity.Property(e => e.Duracao).HasColumnName("DURACAO");

                entity.Property(e => e.NomeCurso)
                    .HasColumnName("NOME_CURSO")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
