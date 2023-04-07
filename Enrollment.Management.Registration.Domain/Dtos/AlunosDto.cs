﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Enrollment.Management.Registration.Domain.Dtos
{
    public class AlunosDto
    {
        [JsonIgnore]
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<MatriculasDto> Matriculas { get; set; }
    }
}
