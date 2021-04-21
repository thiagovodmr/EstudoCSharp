using CAP.ApplicationCore.ViewModels.Matricula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CAP.ApplicationCore.ViewModels.Aluno
{
    public class AlunoViewModel
    {
        [DisplayName("Id")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Data de Nascimento é obrigatória")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public ICollection<MatriculaViewModel> Matriculas { get; set; }
    }
}
