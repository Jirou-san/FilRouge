using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;
using FilRouge.Service;
using FilRouge.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FilRouge.Web.Controllers
{
    public class TechnologyController : Controller
    {
        private IReferenceService _referenceService;

        public TechnologyController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        // GET: Technology
        public ActionResult Index()
        {
            ViewBag.alert = TempData["Alert"];
            var technologyModels = new List<TechnologyModel>();
            var technologies = new List<Technology>(); 

            technologies = _referenceService.GetAllTechnologies();

            if (technologies.Count == 0)
            {
                ViewBag.count = "Aucune technologie trouvée";
            }
            else
            {
                ViewBag.count = string.Format($"{technologies.Count} item(s) trouvé(s)");
                technologies.ForEach(technology => technologyModels.Add(technology.MapToTechnologyModel()));
            }
            return View(technologyModels);
        }

        // GET: Technology/Details/5
        public ActionResult Details(int? id = 0)
        {
            var technologyModel = new TechnologyModel();

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var technology = _referenceService.GetTechnology(id.Value);
                technologyModel = technology.MapToTechnologyModel();
            }
            catch (NotFoundException e)
            {
                TempData["Alert"] = e.Message;
            }

            return View(technologyModel);
        }

        // GET: Technology/Create
        public ActionResult Create()
        {
            var emptyModel = new TechnologyModel();

            return View(emptyModel);
        }

        // POST: Technology/Create
        [HttpPost]
        public ActionResult Create(TechnologyModel technologyModel)
        {
            if (ModelState.IsValid)
            {
                var technology = technologyModel.MapToTechnology();

                try
                {
                    _referenceService.AddTechnology(technology);
                    TempData["Alert"] = string.Format($"Technologie: {technology.Name} (id: {technology.Id}), à bien été ajoutée");
                }
                catch (Exception)
                {
                    TempData["Alert"] = string.Format($"Erreur lors de l'insertion de la technologie: {technology.Name}");
                }
            }
            else
            {
                TempData["Alert"] = "Veuillez renseigner tout les champs";
            }

            return RedirectToAction("Index");
        }

        // GET: Technology/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Technology technology = _referenceService.GetTechnology(id);

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (technology == null)
            {
                return HttpNotFound();
            }

            return View(technology.MapToTechnologyModel());
        }

        // POST: Technology/Edit/5
        [HttpPost]
        public ActionResult Edit(TechnologyModel technologyModel)
        {
            if (ModelState.IsValid)
            {
                var technology = technologyModel.MapToTechnology();

                try
                {
                    _referenceService.UpdateTechnology(technologyModel.MapToTechnology());
                    ViewBag.alert = string.Format($"Technologie {technology.Name} mis à jour");
                }
                catch (Exception)
                {
                    ViewBag.alert = "Erreur lors de la mise à jour de la technologie";
                }
            }
            return View(technologyModel);
        }

        // GET: Technology/Delete/5
        public ActionResult Delete(int id)
        {
            var technology = _referenceService.GetTechnology(id);
            var technologyModel = new TechnologyModel();
            try
            {
                technologyModel = technology.MapToTechnologyModel();
            }
            catch (NotFoundException)
            {
                TempData["Alert"] = "Erreur: Problême durant la suppression de la technologie";
            }
            catch (DbUpdateException e)
            {
                TempData["Alert"] = $"Erreur: Problême durant la suppression de la technologie (id: {id}";

            }
            return View(technologyModel);
        }

        // POST: Technology/Delete/5
        [HttpPost]
        public ActionResult Delete(TechnologyModel technology)
        {

           


            try
            {
                var deletedTechnologyId = _referenceService.DeleteTechnology(technology.Id);

            }
            catch (CustomDbUpdateException e)
            {
                TempData["Alert"] = e.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
