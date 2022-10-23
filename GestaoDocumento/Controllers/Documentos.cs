using GestaoDocumento.Data;
using GestaoDocumento.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDocumento.Controllers
{
    public class Documentos : Controller
    {
        private DocumentoRepository repository = new DocumentoRepository();

        // GET: Documentos
        public ActionResult Index()
        {
            return View(repository.Read());
        }

        // GET: Documentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Documentos/Create
        [HttpPost]
        public ActionResult Create(Documento documento)
        {
            if (ModelState.IsValid)
            {
                repository.Create(documento);
                return RedirectToAction("Index");
            }

            return View(documento);
        }

        // GET: Documentos/Edit/5
        public ActionResult Edit(int id)
        {
            Documento documento = repository.Read(id);

            if (documento == null)
            {
                return View("Error");
            }

            return View(documento);
        }

        // GET: Documentos/Edit/5
        [HttpPost]
        public ActionResult Edit(Documento documento)
        {
            if (ModelState.IsValid)
            {
                repository.Update(documento);
                return RedirectToAction("Index");
            }

            return View(documento);
        }

        // GET: Documentos/Delete/5
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
