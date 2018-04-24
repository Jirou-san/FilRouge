using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;
using FilRouge.Web.Models;
using System;
using System.Collections.Generic;
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
            var technologies = _referenceService.GetAllTechnologies();

            if (technologies.Count == 0)
            {
                ViewBag.count = "No technology Found";
            }
            else
            {
                ViewBag.count = string.Format($"{technologies.Count} items found");
            }

            technologies.ForEach(technology => technologyModels.Add(technology.MapToTechnologyModel()));
            return View(technologyModels);
        }

        // GET: Technology/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var technology = _referenceService.GetTechnology(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology.MapToTechnologyModel());
        }

        // GET: Technology/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Technology/Create
        [HttpPost]
        public ActionResult Create(TechnologyModel technologyModel)
        {
            Technology technology = technologyModel.MapToTechnology();

            try
            {
                _referenceService.AddTechnology(technology);
                ViewBag.message = string.Format($"Technology = {technology.Name}, is inserted (id: {technology.Id})");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Technology/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Technology technology = _referenceService.GetTechnology(id);

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
            var technology = technologyModel.MapToTechnology();

            try
            {
                _referenceService.UpdateTechnology(technologyModel.MapToTechnology());

                ViewBag.alert = string.Format($"Technology = {technology.Name} mis à jour");

                return View();
            }
            catch
            {
                ViewBag.message = string.Format($"Problême durant la mise à jour de la technologie ({technology.Name})");
                return View();
            }
        }

        // GET: Technology/Delete/5
        public ActionResult Delete(int id)
        {
            var technology = _referenceService.GetTechnology(id);
            return View(technology.MapToTechnologyModel());
        }

        // POST: Technology/Delete/5
        [HttpPost]
        public ActionResult Delete(TechnologyModel technology)
        {
            var deletedTechnologyId = _referenceService.DeleteTechnology(technology.Id);

            if (deletedTechnologyId == 0)
            {
                TempData["Alert"] = "Error: Problême durant la suppression de la technologie";
            }
            else
            {
                TempData["Alert"] = string.Format($"Success: suppression de la technologie (id: {deletedTechnologyId})");
            }
            return RedirectToAction("Index");
        }
    }
}
