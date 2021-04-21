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
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<CursoViewModel, Curso>();
            CreateMap<MatriculaViewModel, Matricula>();
        }
    }
}
