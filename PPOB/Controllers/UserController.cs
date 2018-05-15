using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PPOB.Models.User;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using PPOB.Models;

namespace PPOB.Controllers
{
    public class UserController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await GetList();
            return View();
        }

        public async Task<ActionResult> GetList()
        {
            UserRepository Repository = new UserRepository();
            ViewData["ListUser"] = await Repository.GetUser();
            return PartialView("_SimpleGrid");
        }

        [HttpPost]
        public async Task<ActionResult> Create(User model)
        {
            try
            {
                var objNewAdminUser = new ApplicationUser { Photo = model.Photo, NameIdentifier = model.NameIdentifier, UserName = model.UserName, Email = model.Email, PhoneNumber = model.PhoneNumber, RoleId = model.RoleId };
                var AdminUserCreateResult = UserManager.Create(objNewAdminUser, model.Password);

                if (AdminUserCreateResult.Succeeded == true)
                {
                    //string strNewRole = Convert.ToString(Request.Form["Roles"]);

                    //if (strNewRole != "0")
                    //{
                    //    // Put user in role
                    //    UserManager.AddToRole(objNewAdminUser.Id, strNewRole);
                    //}

                    return Redirect("~/Admin/Index");
                }
                else
                {
                    //ViewBag.Roles = GetAllRolesAsSelectList();
                    ViewBag.RoleId = GetAllRoles();
                    ModelState.AddModelError(string.Empty,
                        "Error: Failed to create the user. Check password requirements.");
                    return View();
                    //return View(paramExpandedUserDTO);
                }

                UserRepository Repository = new UserRepository();
                var result = await Repository.CreateUser(model.Name, User.Identity.Name);
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
        
        [HttpPost]
        public async Task<ActionResult> Edit(User model)
        {
            try
            {
                UserRepository Repository = new UserRepository();
                var result = await Repository.EditUser(model.UserID, model.Name, User.Identity.Name);
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
        
        [HttpPost]
        public async Task<ActionResult> Delete(User model)
        {
            try
            {
                UserRepository Repository = new UserRepository();
                var result = await Repository.DeleteUserMMaster(model.UserID, User.Identity.Name);
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