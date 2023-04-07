using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enrollment.Management.Registration.Domain.Dtos
{
    public class MatriculasDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime? DataMatricula { get; set; }
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public decimal? ValorTotal { get; set; }

        [JsonIgnore]
        public AlunosDto Aluno { get; set; }

        [JsonIgnore]
        public CursosDto Curso { get; set; }
    }
}
