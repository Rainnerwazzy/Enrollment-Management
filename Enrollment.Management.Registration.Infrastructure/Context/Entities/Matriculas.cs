using System;
using System.Collections.Generic;

namespace Enrollment.Management.Registration.Infrastructure.Context.Entities
{
    public partial class Matriculas: BaseEntity
    {
        public DateTime? DataMatricula { get; set; }
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public decimal? ValorTotal { get; set; }

        public virtual Alunos Aluno { get; set; }
        public virtual Cursos Curso { get; set; }
    }
}
