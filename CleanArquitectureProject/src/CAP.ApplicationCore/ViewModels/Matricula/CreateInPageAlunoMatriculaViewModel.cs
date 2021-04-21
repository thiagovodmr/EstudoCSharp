using CAP.ApplicationCore.ViewModels.Aluno;
using CAP.ApplicationCore.ViewModels.Curso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CAP.ApplicationCore.ViewModels.Matricula
{
    public class CreateInPageAlunoMatriculaViewModel
    {
        public AlunoViewModel Aluno { get; set; }
        
        public IEnumerable<CursoViewModel> Cursos { get; set; }
        public int CursoId;

        [Required]
        [DisplayName("Data de Inicio")]
        public DateTime DataInicio { get; set; }
        [Required]
        [DisplayName("Data de Conclusão")]
        public DateTime DataFim { get; set; }
    }
}
