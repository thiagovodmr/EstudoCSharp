using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CAP.ApplicationCore.ViewModels.Curso
{
    public class CursoViewModel
    {
        public int CursoId { get; set; }
        [Required]
        public string Titulo { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
