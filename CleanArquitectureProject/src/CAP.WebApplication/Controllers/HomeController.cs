using CAP.ApplicationCore.Interfaces.Services;
using CAP.ApplicationCore.ViewModels.Home;
using CAP.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CAP.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlunoService _alunoService;
        private readonly ICursoService _cursoService;
        private readonly IMatriculaService _matriculaService;

        public HomeController(ILogger<HomeController> logger, IAlunoService alunoService, ICursoService cursoService, IMatriculaService matriculaService)
        {
            _logger = logger;
            _alunoService = alunoService;
            _matriculaService = matriculaService;
            _cursoService = cursoService;
        }

        public IActionResult Index()
        {
            var HomeVM = new HomeViewModel {
                Alunos = _alunoService.SelectAll(),
                Cursos = _cursoService.SelectAll(),
                Matriculas = _matriculaService.SelectAll()
            };
            return View(HomeVM);
        }

        public IActionResult Sobre()
        {
            return View();
        }
        public IActionResult Contatos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
