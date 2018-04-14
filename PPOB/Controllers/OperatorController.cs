using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPOB.Models.Operator;

namespace PPOB.Controllers
{
    public class OperatorController : Controller
    {
        // GET: Operator
        public ActionResult Operator()
        {
            return View();
        }
    }
}