using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPOB.Models.RoleMenu;
using System.Threading.Tasks;


namespace PPOB.Controllers
{
    public class RoleMenuController : Controller
    {
        // GET: RoleMenu
        public async Task<ActionResult> Index()
        {
            await GetList();
            await GetListDetail();
            return View();
        }

        public async Task<ActionResult> GetList()
        {
            RoleMenuRepository Repository = new RoleMenuRepository();
            ViewData["ListRole"] = await Repository.GetRole();
            return PartialView("_SimpleGrid");
        }

        public async Task<ActionResult> GetListDetail()
        {
            RoleMenuRepository Repository = new RoleMenuRepository();
            ViewData["ListDetail"] = await Repository.GetDetail();
            return PartialView("_SimpleGridDdetail");
        }

        //public async Task<ActionResult> GetListDetailById(string Id)
        //{
        //    RoleMenuRepository Repository = new RoleMenuRepository();
        //    var result = await Repository.GetDetailById(Id);
        //    return View(result);
        //}


        public async Task<JsonResult> GetListDetailById(string Id)
        {
            RoleMenuRepository Repository = new RoleMenuRepository();
            var result = await Repository.GetDetailById(Id);

            if (result != null)
            {
                return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return null;
        }

        public async Task <ActionResult> Setting (string RoleId, string MenuIds, string Actives, string Creates, string Updates, string Deletes )
        {
            try
            {
                RoleMenuRepository Repository = new RoleMenuRepository();
                var result = await Repository.Setting(RoleId, MenuIds, Actives, Creates, Updates, Deletes, User.Identity.Name);
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
                return View(false);
            }
        }
    }
}