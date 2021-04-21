using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.Interfaces.Repository;
using CAP.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAP.Infraestructure.Repository
{
    public class CursoRepository : EFRepository<Curso> , ICursoRepository
    {
        public CursoRepository(CAPContext dbContext) : base(dbContext)
        {

        }
    }
}
