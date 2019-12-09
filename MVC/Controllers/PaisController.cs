using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Repositorio;
using Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PaisController : Controller
    {
        public Domain.Repositorio.AssesmentContext AssesmentContext { get; set; }

        public PaisController()
        {
            AssesmentContext = new AssesmentContext();
        }

        // GET: Pais
        public ActionResult Index()
        {
            var pais = this.AssesmentContext.Pais.ToList();

            return View(pais);
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            var pais = this.AssesmentContext.Pais.FirstOrDefault(x => x.Id == id);

            return View(pais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string path = collection["Foto"].ToString();

                var storage = new StorageService();

                FileStream file = new FileStream(path, FileMode.Open);
                var fileName = Path.GetFileName(path);

                var pathStorage = storage.UploadImage(fileName, file).Result;

                var pais = new Pais();
                pais.Nome = collection["Nome"];
                pais.Foto = pathStorage;

                this.AssesmentContext.Pais.Add(pais);
                this.AssesmentContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pais/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}