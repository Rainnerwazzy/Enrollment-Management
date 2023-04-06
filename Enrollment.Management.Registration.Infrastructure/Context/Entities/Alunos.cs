using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enrollment.Management.Registration.Infrastructure.Context.Entities
{
    public partial class Alunos
    {
        public Alunos()
        {
            Matriculas = new HashSet<Matriculas>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlunoId { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Matriculas> Matriculas { get; set; }
    }
}
