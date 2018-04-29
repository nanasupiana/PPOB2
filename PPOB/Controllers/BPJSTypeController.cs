using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PPOB.Models.TypeBPJS;

namespace PPOB.Controllers
{
    public class TypeBPJSController : Controller
    {
        // GET: TypeBPJS
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }

        // GET: Operator
        public async Task<ActionResult> GetList()
        {
            TypeBPJSRepository Repository = new TypeBPJSRepository();
            ViewData["ListTypeBPJS"] = await Repository.GetBPJSType();
            return PartialView("_SimpleGrid");
        }

        // POST: Slider/Create
        [HttpPost]
        public async Task<ActionResult> Create(MasterTypeBPJS model)
        {
            try
            {
                TypeBPJSRepository Repository = new TypeBPJSRepository();
                var result = await Repository.CreateTypeBPJS(model.BPJSId, model.Deskripsi, User.Identity.Name);
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
        public async Task<ActionResult> Edit(MasterTypeBPJS model)
        {
            try
            {
                TypeBPJSRepository Repository = new TypeBPJSRepository();
                var result = await Repository.EditBPJSType(model.BPJSId, model.Deskripsi, User.Identity.Name);
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
        public async Task<ActionResult> Delete(MasterTypeBPJS model)
        {
            try
            {
                TypeBPJSRepository Repository = new TypeBPJSRepository();
                var result = await Repository.DeleteTypeBPJS(model.BPJSId);
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