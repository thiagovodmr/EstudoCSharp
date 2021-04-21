using AutoMapper;
using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.Interfaces.Repository;
using CAP.ApplicationCore.Interfaces.Services;
using CAP.ApplicationCore.ViewModels.Aluno;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CAP.ApplicationCore.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapp;
        public AlunoService(IMapper mapp, IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
            _mapp = mapp;
        }

        public void Add(AlunoViewModel entity)
        {
            var mapAluno = _mapp.Map<Aluno>(entity);
             _alunoRepository.Add(mapAluno);
            
        }

        public void Atualizar(AlunoViewModel entity)
        {
            var mapAluno = _mapp.Map<Aluno>(entity);
            _alunoRepository.Atualizar(mapAluno);
        }

        public void Remover(AlunoViewModel entity)
        {
            var mapAluno = _mapp.Map<Aluno>(entity);
            _alunoRepository.Remover(mapAluno);
        }

        public IEnumerable<AlunoViewModel> SelectAll()
        {
            var alunos = _alunoRepository.SelectAll();
            return _mapp.Map<IEnumerable<AlunoViewModel>>(alunos);
        }

        public AlunoViewModel SelectById(int id)
        {
            var aluno = _alunoRepository.SelectById(id);
            return _mapp.Map<AlunoViewModel>(aluno);
        }

        public AlunoViewModel SelectByIdWithMatriculas(int id)
        {
            var aluno = _alunoRepository.SelectByIdWithMatriculas(id);
            return _mapp.Map<AlunoViewModel>(aluno);
        }

        public IEnumerable<AlunoViewModel> SelectPerson(Expression<Func<AlunoViewModel, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}
