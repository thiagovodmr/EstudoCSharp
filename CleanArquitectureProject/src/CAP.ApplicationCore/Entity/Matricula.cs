using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.Entity
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public int CursoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
       
        public int Turno { get; set; }
       
        public Curso Curso { get; set; }
        public Aluno Aluno { get; set; }
    
    }

}
