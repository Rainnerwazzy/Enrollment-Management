using System;

namespace Enrollment.Management.Students.Infrastructure.Context.Entities
{
    public partial class Alunos : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
    }
}
