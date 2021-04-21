using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.Interfaces.Repository;
using CAP.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAP.Infraestructure.Repository
{
    public class AlunoRepository : EFRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(CAPContext dbContext) : base(dbContext)
        {
                        
        }

        public Aluno SelectByIdWithMatriculas(int id)
        {
            var aluno = _dbContext.Set<Aluno>().Include(a => a.Matriculas)
                                               .ThenInclude(m => m.Curso)
                                               .AsNoTracking()
                                               .FirstOrDefault(a => a.AlunoId == id);
            return aluno;
        }
    }
}
