using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.Entity
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
