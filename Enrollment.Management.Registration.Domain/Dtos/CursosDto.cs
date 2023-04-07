using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Enrollment.Management.Registration.Domain.Dtos
{
    public class CursosDto
    {
        public int CursoId { get; set; }
        public string NomeCurso { get; set; }
        public int? Duracao { get; set; }
        public DateTime? DataLimiteMatricula { get; set; }
        public decimal? Custo { get; set; }
        public ICollection<string> ListDisciplinas { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<MatriculasDto> Matriculas { get; set; }
    }
}
