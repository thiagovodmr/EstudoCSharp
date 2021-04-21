using CAP.ApplicationCore.ViewModels.Aluno;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.ApplicationCore.Interfaces.Services
{
    public interface IAlunoService : IServices<AlunoViewModel>
    {
        public AlunoViewModel SelectByIdWithMatriculas(int id);
    }
}
