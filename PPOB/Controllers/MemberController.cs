using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPOB.Models;
using PPOB.Models.Member;
using System.Threading.Tasks;

namespace PPOB.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }

        // GET: Member
        public async Task<ActionResult> GetList()
        {
            MemberRepository Repository = new MemberRepository();
            ViewData["ListMember"] = await Repository.GetMember();
            return PartialView("_SimpleGrid");
        }

        // POST: Member/Create
        [HttpPost]
        public async Task<ActionResult> Create(MasterMember model)
        {
            try
            {
                MemberRepository Repository = new MemberRepository();
                var result = await Repository.CreateMember(model.NamaMember);
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

        // POST: Member/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(MasterMember model)
        {
            try
            {
                MemberRepository Repository = new MemberRepository();
                var result = await Repository.EditMember(model.MemberId, model.NamaMember);
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

        // POST: Member/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(MasterMember model)
        {
            try
            {
                MemberRepository Repository = new MemberRepository();
                var result = await Repository.DeleteMember(model.MemberId);
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