using EstoqueDotNet.Data.Entidade;
using EstoqueDotNet.Repository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EstoqueDotNet.Controllers
{
    public class ProdutosController : Controller
    {
        //
        // GET: /Produtos/
        public ActionResult Index()
        {
            
            return View(ProdutoRepositorio.GetAll());
        }

        //
        // GET: /Produtos/Details/5
        public ActionResult Details(int id)
        {
            Produto produto = (Produto)ProdutoRepositorio.GetOne(id);
            return View(produto);
        }

        //
        // GET: /Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto prt)
        {
            try
            {
                // TODO: Add insert logic here
                ProdutoRepositorio.Create(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            Produto prt = (Produto)ProdutoRepositorio.GetOne(id);
            return View(prt);
        }

        //
        // POST: /Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produto prt)
        {
            try
            {
                // TODO: Add update logic here
                prt.id_produtos = id;
                ProdutoRepositorio.Edit(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ProdutoRepositorio.GetOne(id));
        }

        //
        // POST: /Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produto prt)
        {
            try
            {
                // TODO: Add delete logic here
                ProdutoRepositorio.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
