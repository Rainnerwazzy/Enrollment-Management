using Enrollment.Management.Registration.Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enrollment.Management.Registration.Infrastructure.Context
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

        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Matriculas> Matriculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alunos>(entity =>
            {
                entity.HasKey(e => e.AlunoId);

                entity.ToTable("ALUNOS");

                entity.Property(e => e.AlunoId).HasColumnName("ALUNO_ID");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(50);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Foto).HasColumnName("FOTO");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.CursoId);

                entity.ToTable("CURSOS");

                entity.Property(e => e.CursoId).HasColumnName("CURSO_ID");

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

            modelBuilder.Entity<Matriculas>(entity =>
            {
                entity.HasKey(e => e.MatriculaId);

                entity.ToTable("MATRICULAS");

                entity.Property(e => e.MatriculaId).HasColumnName("MATRICULA_ID");

                entity.Property(e => e.AlunoId).HasColumnName("ALUNO_ID");

                entity.Property(e => e.CursoId).HasColumnName("CURSO_ID");

                entity.Property(e => e.DataMatricula)
                    .HasColumnName("DATA_MATRICULA")
                    .HasColumnType("datetime");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("VALOR_TOTAL")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALUNOS_ID");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CURSOS_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
