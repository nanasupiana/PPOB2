using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PPOB.Models.PDAM;

namespace PPOB.Controllers
{
    public class PDAMController : Controller
    {
        // GET: PDAM        
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }        
        public async Task<ActionResult> GetList()
        {
            PDAMRepository Repository = new PDAMRepository();
            ViewData["ListPDAM"] = await Repository.GetPDAM();
            return PartialView("_SimpleGrid");
        }        
        [HttpPost]
        public async Task<ActionResult> Create(MasterPDAM model)
        {
            try
            {
                PDAMRepository Repository = new PDAMRepository();
                var result = await Repository.CreatePDAM(model.PDAMId, model.Deskripsi, User.Identity.Name);
                if (result == true)
                {
                    return await GetList();
                }
                else
                {
                    return View(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return View(false);
            }
        }

        // POST: Operator/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(MasterPDAM model)
        {
            try
            {
                PDAMRepository Repository = new PDAMRepository();
                var result = await Repository.EditPDAM(model.PDAMId, model.Deskripsi, User.Identity.Name);
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
        public async Task<ActionResult> Delete(MasterPDAM model)
        {
            try
            {
                PDAMRepository Repository = new PDAMRepository();
                var result = await Repository.DeletePDAM(model.PDAMId, User.Identity.Name);
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