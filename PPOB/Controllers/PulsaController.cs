using PPOB.Models.Pulsa;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web;

namespace PPOB.Controllers
{
    public class PulsaController : Controller
    {

        // GET: Slider
        // GET: Operator
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }

        // GET: Operator
        public async Task<ActionResult> GetList()
        {
            PulsaRepository Repository = new PulsaRepository();
            ViewData["ListPulsa"] = await Repository.GetPulsa();
            return PartialView("_SimpleGrid");
        }

        // POST: Slider/Create
        [HttpPost]
        public async Task<ActionResult> Create(MasterPulsa model)
        {
            try
            {                            
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.CreatePulsa(model.PulsaId, model.Deskripsi, User.Identity.Name);
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
        public async Task<ActionResult> Edit(MasterPulsa model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.EditPulsa(model.PulsaId,model.Deskripsi, User.Identity.Name);
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
        public async Task<ActionResult> Delete(MasterPulsa model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.DeletePulsa(model.PulsaId);
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