using CAP.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace CAP.ApplicationCore.Interfaces.Repository
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        //métodos espeficos para a entidade Matricula
        public IEnumerable<Matricula> SelectAllIncludes();
        public Matricula SelectByIdWithIncludes(int id);
       
    }
}
