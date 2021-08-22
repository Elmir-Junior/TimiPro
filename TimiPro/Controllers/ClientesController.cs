using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimiPro.Data.EF;
using TimiPro.Data.Service;
using TimiPro.Data.Service.Interface;
using TimiPro.Models;

namespace TimiPro.Controllers
{
    public class ClientesController : Controller
    {
        readonly IClienteService _context;
        public ClientesController(IClienteService context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.ListarClientes());
        }

        public ActionResult Details(int id)
        {

            return View(_context.ClientesPeloID(id));
        }

        //GET Create
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {

            if (_context.Email(cliente))
            {
                ModelState.AddModelError("Email", $"Esse Email Já esta sendo Usado");
            }
            if (_context.CPF(cliente))
            {
                ModelState.AddModelError("CPF", $"Esse CPF Já esta sendo Usado");
            }

            if (ModelState.IsValid)
            {
                _context.Adicionar(cliente);

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.ClientesPeloID(id));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Editar(cliente);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Delete/
        public ActionResult Delete(int id)
        {

            return View(_context.ClientesPeloID(id));

        }

        // POST: Clientes/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          _context.Excluir(id);
                return RedirectToAction(nameof(Index));
      
        }
    }
}
