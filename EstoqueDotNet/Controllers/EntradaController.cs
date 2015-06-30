using EstoqueDotNet.Data.Entidade;
using EstoqueDotNet.Repository;
using EstoqueDotNet.Repository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstoqueDotNet.Controllers
{
    public class EntradaController : Controller
    {
        //
        // GET: /Entradas/
        public ActionResult Index()
        {

            return View(EntradaRepositorio.GetAll());
        }

        //
        // GET: /Entradas/Details/5
        public ActionResult Details(int id)
        {
            Entrada Entrada = (Entrada)EntradaRepositorio.GetOne(id);
            ViewBag.CaixaNome = (Caixa)CaixaRepositorio.GetOne(Entrada.caixa_id_caixa);
            ViewBag.ProdutoNome = (Produto)ProdutoRepositorio.GetOne(Entrada.produtos_id_produtos);
            return View(Entrada);
        }

        //
        // GET: /Entradas/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = new SelectList(ProdutoRepositorio.GetAll(), "id_produtos", "nome");
            ViewBag.Caixas = new SelectList(CaixaRepositorio.GetAll(), "id_caixa", "nome");
            return View();
        }

        //
        // POST: /Entradas/Create
        [HttpPost]
        public ActionResult Create(Entrada prt)
        {
            try
            {
                
                // TODO: Add insert logic here
                EntradaRepositorio.Create(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Entradas/Edit/5
        public ActionResult Edit(int id)
        {
            Entrada prt = (Entrada)EntradaRepositorio.GetOne(id);
            return View(prt);
        }

        //
        // POST: /Entradas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Entrada prt)
        {
            try
            {
                // TODO: Add update logic here
                prt.id_entrada = id;
                EntradaRepositorio.Edit(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Entradas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(EntradaRepositorio.GetOne(id));
        }

        //
        // POST: /Entradas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Entrada prt)
        {
            try
            {
                // TODO: Add delete logic here
                EntradaRepositorio.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
