using CAP.ApplicationCore.Interfaces.Services;
using CAP.ApplicationCore.Utils;
using CAP.ApplicationCore.ViewModels.Curso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAP.WebApplication.Controllers
{
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;

        }
        // GET: CursoController
        public ActionResult Index()
        {
            var cursos = _cursoService.SelectAll();
            return View(cursos);
        }

        // GET: CursoController/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            var curso = _cursoService.SelectById(id);
            return View(curso);
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoViewModel curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cursoService.Add(curso);
                    SetFlash(FlashMessageType.Success,"Curso cadastrado com sucesso");
                    return RedirectToAction(nameof(Index));
                }
                return View(curso);

            }
            catch(Exception)
            {
                throw;
            }
        }

        // GET: CursoController/Edit/5
        public ActionResult Edit(int id)
        {
            var curso = _cursoService.SelectById(id);
            return View(curso);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CursoViewModel curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cursoService.Atualizar(curso);
                    SetFlash(FlashMessageType.Success, "Registro Atualizado com sucesso");
                    return RedirectToAction(nameof(Index));
                }
                return View(curso);
            }
            catch(Exception)
            {
                throw;
            }
        }

        // GET: CursoController/Delete/5
        public ActionResult Delete(int id)
        {
            var curso = _cursoService.SelectById(id);
            if(curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: CursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CursoViewModel curso)
        {
            try
            {
                _cursoService.Remover(curso);
                SetFlash(FlashMessageType.Success, "Registro deletado com sucesso");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
