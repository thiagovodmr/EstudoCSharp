using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.ViewModels.Matricula;
using System;
using System.Collections.Generic;
using System.Text;


namespace CAP.ApplicationCore.Interfaces.Services
{
    public interface IMatriculaService : IServices<MatriculaViewModel>
    {
        public IEnumerable<MatriculaViewModel> SelectAllIncludes();
        public MatriculaViewModel SelectByIdWithIncludes(int id);
        
    }
}
