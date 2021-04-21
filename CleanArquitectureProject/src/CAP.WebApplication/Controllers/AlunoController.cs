using CAP.ApplicationCore.Entity;
using CAP.ApplicationCore.Interfaces.Services;
using CAP.ApplicationCore.Utils;
using CAP.ApplicationCore.ViewModels.Aluno;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAP.WebApplication.Controllers
{
    public class AlunoController : ControllerBase
    {

        private readonly IAlunoService _alunoService;
        
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
            
        }

        // GET: AlunoController
        public ActionResult Index()
        {
            var alunos = _alunoService.SelectAll();
            return View(alunos);
        }

        // GET: AlunoController/Detalhes/{id}
        public ActionResult Detalhes(int id)
        {
            var aluno = _alunoService.SelectByIdWithMatriculas(id);
            return View(aluno);
        }

        // GET: AlunoController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoViewModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunoService.Add(aluno);
                    SetFlash(FlashMessageType.Success, "Aluno Cadastrado com sucesso");
                    return RedirectToAction(nameof(Index));
                }
                return View(aluno);
               
            }
            catch(Exception)
            {
                throw;
            }
        }

        // GET: AlunoController/Edit/5
        public ActionResult Edit(int id)
        {
            var aluno = _alunoService.SelectById(id);
            return View(aluno);
        }

        // POST: AlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlunoViewModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunoService.Atualizar(aluno);
                    SetFlash(FlashMessageType.Success, "Cadastrado atualizado com sucesso");
                    return RedirectToAction(nameof(Index));
                }
                return View(aluno);
              
            }
            catch(Exception)
            {
                throw;
            }
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(int id)
        {
            var aluno = _alunoService.SelectById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            
            return View(aluno);
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AlunoViewModel aluno)
        {
            try
            {
                _alunoService.Remover(aluno);
                SetFlash(FlashMessageType.Success, "Registro Deletado com sucesso");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
