using CAP.ApplicationCore.Interfaces.Services;
using CAP.ApplicationCore.Utils;
using CAP.ApplicationCore.ViewModels.Matricula;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace CAP.WebApplication.Controllers
{
    public class MatriculaController : ControllerBase
    {
        // GET: MatriculaController
        private readonly IAlunoService _alunoService;
        private readonly ICursoService _cursoService;
        private readonly IMatriculaService _matriculaService;
        public MatriculaController(IAlunoService alunoService, ICursoService cursoService, IMatriculaService matriculaService)
        {
            _alunoService = alunoService;
            _cursoService = cursoService;
            _matriculaService = matriculaService;
        }

        public ActionResult Index()
        {
            var matriculas = _matriculaService.SelectAllIncludes();
            return View(matriculas);
        }

        // GET: MatriculaController/detalhes/5
        public ActionResult Detalhes(int id)
        {
            var matricula = _matriculaService.SelectByIdWithIncludes(id);
            return View(matricula);
        }

        // GET: MatriculaController/Create
        public ActionResult Create(int id)
        {
            var matriculaVM = new MatriculaViewModel {
                Aluno = _alunoService.SelectById(id),
                Cursos = _cursoService.SelectAll()
            };
        
            return View(matriculaVM);
        }

        // POST: MatriculaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatriculaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _matriculaService.Add(model);
                    SetFlash(FlashMessageType.Success, "Cadastro realizado com sucesso");
                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                var matriculaVM = new MatriculaViewModel
                {
                    Aluno = _alunoService.SelectById(model.AlunoId),
                    Cursos = _cursoService.SelectAll()
                };

                var exception = e.InnerException != null ? ((SqlException)e.InnerException).Number : 0;
                if (exception == 2627 || exception == 2601)
                {
                    SetFlash(FlashMessageType.Danger, "Este aluno já está matriculado em algum curso neste mesmo periodo");          
                }
                else
                {
                    SetFlash(FlashMessageType.Danger, e.Message);
                }

                return View(matriculaVM);

            }
           
        }

        // GET: MatriculaController/Edit/5
        public ActionResult Edit(int id)
        {
            var matricula = _matriculaService.SelectByIdWithIncludes(id);
            return View(matricula);
        }

        // POST: MatriculaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MatriculaViewModel matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _matriculaService.Atualizar(matricula);
                    SetFlash(FlashMessageType.Success, "atualizado com sucesso");
                    return RedirectToAction(nameof(Index));
                }
                return View(matricula);
            }
            catch(Exception e)
            {
               var matriculaVM = _matriculaService.SelectByIdWithIncludes(matricula.MatriculaId);

                SetFlash(FlashMessageType.Danger, e.Message);
                return View(matriculaVM);
            }
        }

        // GET: MatriculaController/Delete/5
        public ActionResult Delete(int id)
        {
            var matricula = _matriculaService.SelectByIdWithIncludes(id);
            if(matricula == null)
            {
                return NotFound();
            }
            return View(matricula);
        }

        // POST: MatriculaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MatriculaViewModel matricula)
        {
            try
            {
                _matriculaService.Remover(matricula);
                SetFlash(FlashMessageType.Success, "Registro Deletado com sucesso");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
