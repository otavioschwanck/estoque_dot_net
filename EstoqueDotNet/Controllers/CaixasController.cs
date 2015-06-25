using EstoqueDotNet.Data.Entidade;
using EstoqueDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstoqueDotNet.Controllers
{
    public class CaixasController : Controller
    {
        //
        // GET: /Caixas/
        public ActionResult Index()
        {

            return View(CaixaRepositorio.GetAll());
        }

        //
        // GET: /Caixas/Details/5
        public ActionResult Details(int id)
        {
            Caixa Caixa = (Caixa)CaixaRepositorio.GetOne(id);
            return View(Caixa);
        }

        //
        // GET: /Caixas/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Caixas/Create
        [HttpPost]
        public ActionResult Create(Caixa prt)
        {
            try
            {
                // TODO: Add insert logic here
                CaixaRepositorio.Create(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Caixas/Edit/5
        public ActionResult Edit(int id)
        {
            Caixa prt = (Caixa)CaixaRepositorio.GetOne(id);
            return View(prt);
        }

        //
        // POST: /Caixas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Caixa prt)
        {
            try
            {
                // TODO: Add update logic here
                prt.id_caixa = id;
                CaixaRepositorio.Edit(prt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Caixas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CaixaRepositorio.GetOne(id));
        }

        //
        // POST: /Caixas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Caixa prt)
        {
            try
            {
                // TODO: Add delete logic here
                CaixaRepositorio.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
