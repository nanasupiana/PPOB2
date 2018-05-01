using PPOB.Models.MasterMenu;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web;
using PPOB.Models;

namespace PPOB.Controllers
{
    public class MasterMenuController : Controller
    {

        public async Task<ActionResult> Index()
        {
            await GetListMasterMenu();
            MasterMenuRepository Repository = new MasterMenuRepository();
            ViewData["ListParent"] = await Repository.GetParent();
            return View();
        }

        public async Task<ActionResult> GetListMasterMenu()
        {
            MasterMenuRepository Repository = new MasterMenuRepository();
            ViewData["ListMasterMenu"] = await Repository.GetMasterMenu();
            return PartialView("_SimpleGrid");
        }

        [HttpPost]
        public async Task<ActionResult> Create(MasterMenu model)
        {
            try
            {
                MasterMenuRepository Repository = new MasterMenuRepository();
                var result = await Repository.CreateMasterMenu(model.MenuName, model.MenuURL, model.MenuIcon, model.MenuParentId, User.Identity.Name);
                if (result == true)
                {
                    return await GetListMasterMenu();
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
        
        [HttpPost]
        public async Task<ActionResult> Edit(MasterMenu model)
        {
            try
            {
                MasterMenuRepository Repository = new MasterMenuRepository();
                var result = await Repository.EditMasterMenu(model.MenuId, model.MenuName, model.MenuURL, model.MenuIcon, model.MenuParentId, User.Identity.Name);
                if (result == true)
                {
                    return await GetListMasterMenu();
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
        
        [HttpPost]
        public async Task<ActionResult> Delete(MasterMenu model)
        {
            try
            {
                MasterMenuRepository Repository = new MasterMenuRepository();
                var result = await Repository.DeleteMasterMenu(model.MenuId, User.Identity.Name);
                if (result == true)
                {
                    return await GetListMasterMenu();
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