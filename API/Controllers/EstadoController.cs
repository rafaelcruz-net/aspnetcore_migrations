using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EstadoController : Controller
    {
        public Domain.Repositorio.AssesmentContext AssesmentContext { get; set; }

        public EstadoController()
        {
            AssesmentContext = new AssesmentContext();
        }

        // GET: api/Estado
        [HttpGet]
        public IEnumerable<Estado> Get()
        {
            return this.AssesmentContext.Estados.ToList();
        }

        // GET: api/Estado/5
        [HttpGet("{id}", Name = "Get")]
        public Estado Get(int id)
        {
            return this.AssesmentContext.Estados
                       .FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Estado
        [HttpPost]
        public void Post([FromBody]Estado estado)
        {

            this.AssesmentContext.Estados.Add(estado);
            this.AssesmentContext.SaveChanges();

        }
        
        // PUT: api/Estado/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Estado estado)
        {
            var estadoOld = this.AssesmentContext.Estados.FirstOrDefault(x => x.Id == id);

            estadoOld.Nome = estado.Nome;
            estadoOld.Foto = estado.Foto;

            this.AssesmentContext.Entry<Estado>(estadoOld)
                .State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            this.AssesmentContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var estado = this.AssesmentContext.Estados.FirstOrDefault(x => x.Id == id);

            this.AssesmentContext.Estados.Remove(estado);
            this.AssesmentContext.SaveChanges();

        }
    }
}
