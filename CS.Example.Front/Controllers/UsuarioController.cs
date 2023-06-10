using CS.Example.Business.Interfaces.Usuarios;
using CS.Example.Common;
using CS.Example.Common.Interfaces;
using CS.Example.Common.Models;
using CS.Example.Front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS.Example.Front.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IBusinessUsuario _businessUsuario;

        public UsuarioController(IBusinessUsuario businessUsuario) 
        {
            _businessUsuario = businessUsuario;
        }

        // GET: UsuarioController
        public async Task<ActionResult> Index(int initRow = 1, int finishRow = 10, string? word = null)
        {
            var rUSuarios = await _businessUsuario.Get(initRow, finishRow, word);

            if (rUSuarios.Success)
            {
                return View(rUSuarios.Data);
            }

            return View("Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            OperationResult<Usuario?> rOperationResult;

            try
            {
                if (usuario.IdUsuario == Guid.Empty)
                {
                    rOperationResult = await _businessUsuario.Post(usuario);
                }
                else
                {
                    rOperationResult = await _businessUsuario.Put(usuario);
                }               

                if (!rOperationResult.Success)
                {
                    return View("Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid idUsuario)
        {
            try
            { 
                var rOperationResult = await _businessUsuario.Delete(idUsuario);

                if (!rOperationResult.Success)
                {
                    return View("Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
