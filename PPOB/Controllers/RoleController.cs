using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web;
using PPOB.Models.RoleMaster;

namespace PPOB.Controllers
{
    public class RoleController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }
        
        public async Task<ActionResult> GetList()
        {
            RoleRepository Repository = new RoleRepository();
            ViewData["ListRoleMaster"] = await Repository.GetRoleMaster();
            return PartialView("_SimpleGrid");
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(MasterRole model)
        {
            try
            {                           

                RoleRepository Repository = new RoleRepository();
                var result = await Repository.CreateRoleMaster(model.Name, User.Identity.Name);
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
        public async Task<ActionResult> Edit(MasterRole model)
        {
            try
            {
                RoleRepository Repository = new RoleRepository();
                var result = await Repository.EditRoleMaster(model.RoleID,model.Name, User.Identity.Name);
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
        public async Task<ActionResult> Delete(MasterRole model)
        {
            try
            {
                RoleRepository Repository = new RoleRepository();
                var result = await Repository.DeleteRoleMMaster(model.RoleID, User.Identity.Name);
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