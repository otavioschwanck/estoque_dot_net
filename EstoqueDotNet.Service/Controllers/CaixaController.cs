using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EstoqueDotNet.Data.Entidade;
using EstoqueDotNet.Repository;

namespace EstoqueDotNet.Service.Controllers
{
    public class CaixaController : Controller
    {
        //
        // GET: /Caixa/

        public IEnumerable<Caixa> Get()
        {
            var caixas = CaixaRepositorio.GetAll();

            return caixas;
        }

        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Caixa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Caixa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Caixa/5
        public void Delete(int id)
        {
        }
	}
}