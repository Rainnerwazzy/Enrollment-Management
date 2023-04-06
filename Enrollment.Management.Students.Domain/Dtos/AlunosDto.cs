using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enrollment.Management.Students.Domain.Dtos
{
    public class AlunosDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
    }
}
