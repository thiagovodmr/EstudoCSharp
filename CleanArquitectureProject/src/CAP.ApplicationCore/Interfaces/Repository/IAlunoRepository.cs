using CAP.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.Interfaces.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        //metodos especificos para a entidade aluno
        public Aluno SelectByIdWithMatriculas(int id);
    }
}
