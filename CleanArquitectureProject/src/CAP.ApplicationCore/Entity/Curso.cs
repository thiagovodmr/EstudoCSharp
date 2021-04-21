using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.Entity
{
    public class Curso
    {
        public int CursoId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
