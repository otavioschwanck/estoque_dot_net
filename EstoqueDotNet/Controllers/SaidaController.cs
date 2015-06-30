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
    public class SaidaController : Controller
    {
        //
        // GET: /Saidas/
        public ActionResult Index()
        {

            return View(SaidaRepositorio.GetAll());
        }

        //
        // GET: /Saidas/Details/5
        public ActionResult Details(int id)
        {
            Saida Saida = (Saida)SaidaRepositorio.GetOne(id);
            ViewBag.CaixaNome = (Caixa)CaixaRepositorio.GetOne(Saida.caixa_id_caixa);
            ViewBag.ProdutoNome = (Produto)ProdutoRepositorio.GetOne(Saida.produtos_id_produtos);
            return View(Saida);
        }

        //
        // GET: /Saidas/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = new SelectList(ProdutoRepositorio.GetAll(), "id_produtos", "nome");
            ViewBag.Caixas = new SelectList(CaixaRepositorio.GetAll(), "id_caixa", "nome");
            return View();
        }

        //
        // POST: /Saidas/Create
        [HttpPost]
        public ActionResult Create(Saida prt)
        {
            try
            {
                
                // TODO: Add insert logic here
                SaidaRepositorio.Create(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Saidas/Edit/5
        public ActionResult Edit(int id)
        {
            Saida prt = (Saida)SaidaRepositorio.GetOne(id);
            return View(prt);
        }

        //
        // POST: /Saidas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Saida prt)
        {
            try
            {
                // TODO: Add update logic here
                prt.id_saida = id;
                SaidaRepositorio.Edit(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Saidas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(SaidaRepositorio.GetOne(id));
        }

        //
        // POST: /Saidas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Saida prt)
        {
            try
            {
                // TODO: Add delete logic here
                SaidaRepositorio.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
