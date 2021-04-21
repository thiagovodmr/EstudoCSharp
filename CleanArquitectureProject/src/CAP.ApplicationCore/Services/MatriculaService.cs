using AutoMapper;
using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.Interfaces.Repository;
using CAP.ApplicationCore.Interfaces.Services;
using CAP.ApplicationCore.ViewModels.Matricula;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace CAP.ApplicationCore.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IMapper _mapp;

        public MatriculaService(IMapper mapp,IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
            _mapp = mapp;
        }

        public void Add(MatriculaViewModel entity)
        {
            if (IsValidDataRange(entity.DataInicio, entity.DataFim))
            {
                var mapMatricula = _mapp.Map<Matricula>(entity);
                _matriculaRepository.Add(mapMatricula);
            }
            else
            {
                throw new Exceptions.DataPeriodoException("Data de Inicio não pode vir depois da data de conclusão do curso ");
            }
            
        }

        public bool IsValidDataRange(DateTime dataInicio, DateTime dataFim)
        {
            return (DateTime.Compare(dataInicio, dataFim) < 0);         
        }

        public void Atualizar(MatriculaViewModel entity)
        {
            if (IsValidDataRange(entity.DataInicio, entity.DataFim))
            {
                var mapEntity = _mapp.Map<Matricula>(entity);
                _matriculaRepository.Atualizar(mapEntity);
            }
            else
            {
                throw new Exceptions.DataPeriodoException("Data de Inicio não pode vir depois da data de conclusão do curso ");
            }
        }

        public void Remover(MatriculaViewModel entity)
        {
            var mapMatricula = _mapp.Map<Matricula>(entity);
            _matriculaRepository.Remover(mapMatricula);
        }

        public IEnumerable<MatriculaViewModel> SelectAll()
        {
            var matriculas = _matriculaRepository.SelectAll();
            return  _mapp.Map<IEnumerable<MatriculaViewModel>>(matriculas);
        }

        public IEnumerable<MatriculaViewModel> SelectAllIncludes()
        {
            var matriculas = _matriculaRepository.SelectAllIncludes();
            return  _mapp.Map<IEnumerable<MatriculaViewModel>>(matriculas);
            
        }

        public MatriculaViewModel SelectById(int id)
        {
            var matricula = _matriculaRepository.SelectById(id);
            return _mapp.Map<MatriculaViewModel>(matricula);
        }

        public MatriculaViewModel SelectByIdWithIncludes(int id)
        {
            var matricula = _matriculaRepository.SelectByIdWithIncludes(id);
            return _mapp.Map<MatriculaViewModel>(matricula);
        }

        public IEnumerable<MatriculaViewModel> SelectPerson(Expression<Func<MatriculaViewModel, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}
