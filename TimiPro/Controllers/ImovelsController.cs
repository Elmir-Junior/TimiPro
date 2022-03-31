using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimiPro.Data.EF;
using TimiPro.Data.Service.Interface;
using TimiPro.Models;

namespace TimiPro.Controllers
{
    public class ImovelsController : Controller
    {
        readonly IImovelService _context;
        readonly IClienteService _contextCliente;

        public ImovelsController(IImovelService context, IClienteService contextCliente)
        {
            _context = context;
            _contextCliente = contextCliente;
        }

        public IActionResult Index()
        {
            return View(_context.ListarImovel());
        }

        public IActionResult Details(int id)
        {
            var teste = _context.ImovelPeloID(id);
            return View(teste);

        }

        //GET Create
        public IActionResult Create()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem
            {
                Text = "Selecione",
                Value = ""
            });
            foreach (var linha in _contextCliente.ListarClientes().Where(m => m.Ativo))
            {
                lista.Add(new SelectListItem()
                {
                    Value = linha.Nome,
                    Text = linha.Nome,
                });
            }
            ViewBag.Selecionador = lista;
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,TipoNegocio,Valor,Descricao,Ativo,ClienteNome")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Adicionar(imovel);

                return RedirectToAction(nameof(Index));
            }
            return View(imovel);
        }

        //GET Edit
        public IActionResult Edit(int id)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem
            {
                Text = "Selecione",
                Value = ""
            });
            foreach (var linha in _contextCliente.ListarClientes().Where(m => m.Ativo))
            {
                lista.Add(new SelectListItem()
                {
                    Value = linha.Nome,
                    Text = linha.Nome,
                });
            }
            ViewBag.Selecionador = lista;
            return View(_context.ImovelPeloID(id));
        }

        //POST EDit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ID,TipoNegocio,Valor,Descricao,Ativo,ClienteNome")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Editar(imovel);
            }

            return RedirectToAction(nameof(Index));
        }

        //GET Delete
        public ActionResult Delete(int id)
        {

            if (_context.ImovelPeloID(id).ClienteNome != null)
            {

                TempData["mensagemErro"] = "Não é possivel realizar a exclusão de um imóvel que esteja relacionado a um cliente";

            }

            return View(_context.ImovelPeloID(id));

        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _context.Excluir(id);


            return RedirectToAction(nameof(Index));
        }
    }
}
