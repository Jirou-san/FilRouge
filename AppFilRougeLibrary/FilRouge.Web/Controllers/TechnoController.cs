using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilRouge.Services;
namespace FilRouge.Web.Controllers
{
    public class TechnoController : Controller
    {
        private ReferencesService service = new ReferencesService();

        // GET: Techno
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetTechno(int id)
        {
            var techno = this.service.GetTechnologies();
            return this.View();
        }
    }
}