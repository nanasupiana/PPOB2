using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PPOB.Models.TypeMember;


namespace PPOB.Controllers
{
    public class TypeMemberController : Controller
    {
        // GET: TypeMember
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }

        // GET: Operator
        public async Task<ActionResult> GetList()
        {
            TypeMemberRepository Repository = new TypeMemberRepository();
            ViewData["ListTypeMember"] = await Repository.GetTypeMember();
            return PartialView("_SimpleGrid");
        }

        // POST: Slider/Create
        [HttpPost]
        public async Task<ActionResult> Create(MasterTypeMember model)
        {
            try
            {                
                TypeMemberRepository Repository = new TypeMemberRepository();
                var result = await Repository.CreateTypeMember(model.TypeMember,model.Deskripsi, User.Identity.Name);
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
        public async Task<ActionResult> Edit(MasterTypeMember model)
        {
            try
            {
                TypeMemberRepository Repository = new TypeMemberRepository();
                var result = await Repository.EditTypeMember(model.TypeMember, model.Deskripsi, User.Identity.Name);
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
        public async Task<ActionResult> Delete(MasterTypeMember model)
        {
            try
            {
                TypeMemberRepository Repository = new TypeMemberRepository();
                var result = await Repository.DeleteTypeMember(model.TypeMember);
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