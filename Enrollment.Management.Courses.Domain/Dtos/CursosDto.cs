﻿using System;
using System.Collections.Generic;

namespace Enrollment.Management.Courses.Domain.Dtos
{
    public class CursosDto
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; }
        public int? Duracao { get; set; }
        public DateTime? DataLimiteMatricula { get; set; }
        public decimal? Custo { get; set; }
        public ICollection<string> ListDisciplinas { get; set; }
    }
}
