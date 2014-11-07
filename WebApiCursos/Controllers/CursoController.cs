using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebSockets;
using WebApiCursos.Models;
using WebApiCursos.Models.ViewModel;
using WebApiCursos.Repositorio;

namespace WebApiCursos.Controllers
{
    public class CursoController : ApiController
    {
        private IRepositorio<CursoViewModel,Curso> repo=
            new Repositorio<CursoViewModel,Curso> 
                (new cursoEntities());

        // GET: api/Curso
        public IEnumerable<CursoViewModel> Get()
        {
            return repo.Get();
        }

        // GET: api/Curso/5
        public CursoViewModel Get(int id)
        {
            return repo.Get(id);
        }

        // POST: api/Curso
        public void Post([FromBody]CursoViewModel value)
        {
            repo.Add(value);
        }

        // PUT: api/Curso/5
        public void Put([FromBody]CursoViewModel value)
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
