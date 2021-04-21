using AutoMapper;
using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.Interfaces.Repository;
using CAP.ApplicationCore.Interfaces.Services;
using CAP.ApplicationCore.ViewModels.Curso;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CAP.ApplicationCore.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapp;
        public CursoService(IMapper mapp, ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
            _mapp = mapp;
        }

        public void Add(CursoViewModel entity)
        {
            var mapCurso = _mapp.Map<Curso>(entity);
            _cursoRepository.Add(mapCurso);
        }

        public void Atualizar(CursoViewModel entity)
        {
            var mapcurso = _mapp.Map<Curso>(entity);
            _cursoRepository.Atualizar(mapcurso);
        }

        public void Remover(CursoViewModel entity)
        {
            var mapcurso = _mapp.Map<Curso>(entity);
            _cursoRepository.Remover(mapcurso);
        }

        public IEnumerable<CursoViewModel> SelectAll()
        {
            var cursos = _cursoRepository.SelectAll();
            return _mapp.Map<IEnumerable<CursoViewModel>>(cursos);
        }

        public CursoViewModel SelectById(int id)
        {
            var curso = _cursoRepository.SelectById(id);
            return _mapp.Map<CursoViewModel>(curso);
        }

        public IEnumerable<CursoViewModel> SelectPerson(Expression<Func<CursoViewModel, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}
