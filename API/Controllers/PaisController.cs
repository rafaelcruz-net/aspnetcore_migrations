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
    public class PaisController : Controller
    {
        public Domain.Repositorio.AssesmentContext AssesmentContext { get; set; }

        public PaisController()
        {
            AssesmentContext = new AssesmentContext(); 
        }

        // GET: api/Estado
        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            return this.AssesmentContext.Pais.ToList();
        }

        // GET: api/Estado/5
        [HttpGet("{id}", Name = "Get")]
        public Pais Get(int id)
        {
            return this.AssesmentContext.Pais
                       .FirstOrDefault(x => x.Id == id);
        }

        // POST: api/Estado
        [HttpPost]
        public void Post([FromBody]Pais pais)
        {

            this.AssesmentContext.Pais.Add(pais);
            this.AssesmentContext.SaveChanges();

        }

        // PUT: api/Estado/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Pais estado)
        {
            var paisOld = this.AssesmentContext.Pais.FirstOrDefault(x => x.Id == id);

            paisOld.Nome = estado.Nome;
            paisOld.Foto = estado.Foto;

            this.AssesmentContext.Entry<Pais>(paisOld)
                .State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            this.AssesmentContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pais = this.AssesmentContext.Pais.FirstOrDefault(x => x.Id == id);

            this.AssesmentContext.Pais.Remove(pais);
            this.AssesmentContext.SaveChanges();

        }


    }
}