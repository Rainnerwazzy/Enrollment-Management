using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enrollment.Management.Registration.Infrastructure.Context.Entities
{
    public partial class Cursos
    {
        public Cursos()
        {
            Matriculas = new HashSet<Matriculas>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoId { get; set; }

        public string NomeCurso { get; set; }
        public int? Duracao { get; set; }
        public DateTime? DataLimiteMatricula { get; set; }
        public decimal? Custo { get; set; }
        public string Disciplina { get; set; }

        public virtual ICollection<Matriculas> Matriculas { get; set; }
    }
}
