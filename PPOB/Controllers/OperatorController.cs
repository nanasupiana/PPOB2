using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPOB.Models;
using PPOB.Models.Operator;
using System.Threading.Tasks;

namespace PPOB.Controllers
{
    public class OperatorController : Controller
    {

        // GET: Operator
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }

        // GET: Operator
        public async Task<ActionResult> GetList()
        {
            OperatorRepository Repository = new OperatorRepository();
            ViewData["ListOperator"] = await Repository.GetOperator();
            return PartialView("_SimpleGrid");
        }

        // POST: Operator/Create
        [HttpPost]
        public async Task<ActionResult> Create( MasterOperator model)
        {
            try
            {
                OperatorRepository Repository = new OperatorRepository();
                var result = await Repository.CreateOperator(model.NamaOperator);
                if (result == true)
                {
                    return await GetList();
                }
                else
                {
                    return View(result);
                }
            }
            catch
            {
                return View(false);
            }
        }

        // POST: Operator/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(MasterOperator model)
        {
            try
            {
                OperatorRepository Repository = new OperatorRepository();
                var result = await Repository.EditOperator(model.IdOperator, model.NamaOperator);
                if (result == true)
                {
                    return await GetList();
                }
                else
                {
                    return View(result);
                }
            }
            catch
            {
                return View(false);
            }
        }

        // POST: Operator/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(MasterOperator model)
        {
            try
            {
                OperatorRepository Repository = new OperatorRepository();
                var result = await Repository.DeleteOperator(model.IdOperator);
                if (result == true)
                {
                    return await GetList();
                }
                else
                {
                    return View(result);
                }
            }
            catch
            {
                return View(false);
            }
        }
    }
}
