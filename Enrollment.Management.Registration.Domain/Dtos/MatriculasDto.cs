using Enrollment.Management.Registration.Domain.Helpers;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enrollment.Management.Registration.Domain.Dtos
{
    public class MatriculasDto
    {
        [SwaggerExclude]
        public int Id { get; set; }
        public DateTime? DataMatricula { get; set; }
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public decimal? ValorTotal { get; set; }

        [SwaggerExclude]
        public AlunosDto Aluno { get; set; }
        [SwaggerExclude]
        public CursosDto Curso { get; set; }
    }
}
