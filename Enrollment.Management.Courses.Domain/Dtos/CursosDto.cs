using Newtonsoft.Json;
using System;

namespace Enrollment.Management.Courses.Domain.Dtos
{
    public class CursosDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string NomeCurso { get; set; }
        public int? Duracao { get; set; }
        public DateTime? DataLimiteMatricula { get; set; }
        public decimal? Custo { get; set; }
        public string Disciplina { get; set; }
    }
}
