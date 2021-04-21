using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.Interfaces.Repository;
using CAP.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace CAP.Infraestructure.Repository
{
    public class MatriculaRepository : EFRepository<Matricula> , IMatriculaRepository
    {
      
        public MatriculaRepository(CAPContext dbContext) : base(dbContext) 
        {  }

        public IEnumerable<Matricula> SelectAllIncludes()
        {
            var matriculas = _dbContext.Set<Matricula>().Include(m => m.Aluno)
                                                        .Include(m => m.Curso)
                                                        .AsNoTracking();
                                                        
            return matriculas;
        }

        public Matricula SelectByIdWithIncludes(int id)
        {
            var matricula =  _dbContext.Set<Matricula>().Include(m => m.Aluno)
                                                        .Include(m => m.Curso)
                                                        .AsNoTracking()
                                                        .FirstOrDefault(m => m.MatriculaId == id);
                                                                                           
            return matricula;
        }

    }
}
