using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCursos.Models;
using WebApiCursos.Repositorio;

namespace WebApiCursos.Controllers
{
    public class CursoController : ApiController
    {
        private Repositorio<Curso>  repo=new Repositorio<Curso>(new cursoEntities());

        // GET: api/Curso
        public IEnumerable<Curso> Get()
        {
            return repo.Get();
        }

        // GET: api/Curso/5
        public Curso Get(int id)
        {
            return repo.Get(id);
        }

        // POST: api/Curso
        public void Post([FromBody]Curso value)
        {
            repo.Add(value);
        }

        // PUT: api/Curso/5
        public void Put([FromBody]Curso value)
        {
            repo.Actualizar(value);
        }

        // DELETE: api/Curso/5
        public void Delete(int id)
        {
            repo.Borrar(id);
        }
    }
}
