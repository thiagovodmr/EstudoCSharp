using CAP.ApplicationCore.ViewModels.Aluno;
using CAP.ApplicationCore.ViewModels.Curso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CAP.ApplicationCore.ViewModels.Matricula
{
    public class MatriculaViewModel
    {
        [DisplayName("Id da Matricula")]
        public int MatriculaId { get; set; }

        [DisplayName("Id do curso")]
        public int CursoId { get; set; }
        [DisplayName("Id do Aluno")]
        public int AlunoId { get; set; }

        [Required]
        [DisplayName("Data de Inicio")]
        public DateTime DataInicio { get; set; }
        [Required]
        [DisplayName("Data de Conclusão")]
        public DateTime DataFim { get; set; }

        public AlunoViewModel Aluno { get; set; }
        public CursoViewModel Curso { get; set; }

        [DisplayName("Turno")]
        public Turnos Turno { get; set; }

        //para carregar os cursos no dropdown formulário 
        public IEnumerable<CursoViewModel> Cursos { get; set; }
    }
    
    public enum Turnos
    {
        [Display(Name ="Manhã")]
        Manha,
        Tarde,
        Noite
    }

}
