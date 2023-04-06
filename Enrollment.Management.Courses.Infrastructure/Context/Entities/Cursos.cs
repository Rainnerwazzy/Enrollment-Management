using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Enrollment.Management.Courses.Infrastructure.Context.Entities
{
    public partial class Cursos : BaseEntity
    {
        public string NomeCurso { get; set; }
        public int? Duracao { get; set; }
        public DateTime? DataLimiteMatricula { get; set; }
        public decimal? Custo { get; set; }
        public string Disciplina { get; set; }
    }
}
