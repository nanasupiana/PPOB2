using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PPOB.Models.Operator;

namespace PPOB.Controllers
{
    public class OperatorController : Controller
    {
        // GET: Operator
        public async Task<ActionResult> Operator()
        {
            await GetOperator();
            return View();
        }

        public async Task<ActionResult> GetOperator()
        {
            ViewData["ListOeraator"] = await OperatorRepository.GetOperator();
            return PartialView("_SimpleGrid");
        }
    }
}