using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostProject.Controllers
{
    public class AngularController : Controller
    {
        // GET: Angular
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PhoneList()
        {
            return PartialView("_PhoneList");
        }
        [HttpGet]
        public ActionResult TabletList()
        {
            return PartialView("_TabletList");
        }
    }
}