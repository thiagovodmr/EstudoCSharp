using CAP.ApplicationCore.ViewModels.Aluno;
using CAP.ApplicationCore.ViewModels.Curso;
using CAP.ApplicationCore.ViewModels.Matricula;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<AlunoViewModel> Alunos;
        public IEnumerable<CursoViewModel> Cursos;
        public IEnumerable<MatriculaViewModel> Matriculas;
    }
}
