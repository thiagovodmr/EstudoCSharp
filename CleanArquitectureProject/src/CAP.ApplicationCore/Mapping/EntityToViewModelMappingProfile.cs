using AutoMapper;
using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.ViewModels.Aluno;
using CAP.ApplicationCore.ViewModels.Curso;
using CAP.ApplicationCore.ViewModels.Matricula;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.Mapping
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<Curso, CursoViewModel>();
            CreateMap<Matricula, MatriculaViewModel>();
        }
    }
}
