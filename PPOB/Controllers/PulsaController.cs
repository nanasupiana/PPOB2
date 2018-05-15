using PPOB.Models.Pulsa;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web;
using PPOB.Controllers;
using System.Collections.Generic;
using PPOB.Models;

namespace PPOB.Controllers
{
    public class PulsaController : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            await GetListPulsa();
            await GetListOperator("");
            return View();
        }
        
        public async Task<ActionResult> GetListPulsa()
        {
            PulsaRepository Repository = new PulsaRepository();
            ViewData["ListPulsa"] = await Repository.GetPulsa();
            return PartialView("_SimpleGridPulsa");
        }

        public async Task<ActionResult> GetListOperator(string PulsaID)
        {
            PulsaRepository Repository = new PulsaRepository();
            ViewData["ListOperator"] = await Repository.GetOperator(PulsaID);
            return PartialView("_SimpleGridOperator");
        }

        [HttpPost]
        public async Task<ActionResult> CreatePulsa(MasterPulsa model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.CreatePulsa(model.PulsaId, model.Deskripsi, User.Identity.Name);
                if (result == true)
                {
                    return await GetListPulsa();
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
        public async Task<ActionResult> CreateOperator(MasterOperator model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.CreateOperator(model.OperatorId, model.PulsaId, model.NamaOperator, User.Identity.Name);
                if (result == true)
                {
                    return await GetListOperator(model.PulsaId);
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
        public async Task<ActionResult> EditPulsa(MasterPulsa model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.EditPulsa(model.PulsaId, model.Deskripsi, User.Identity.Name);
                if (result == true)
                {
                    return await GetListPulsa();
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
        public async Task<ActionResult> EditOperator(MasterOperator model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.EditOperator(model.OperatorId, model.PulsaId, model.NamaOperator, User.Identity.Name);
                if (result == true)
                {
                    return await GetListOperator(model.PulsaId);
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
        public async Task<ActionResult> DeletePulsa(MasterPulsa model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.DeletePulsa(model.PulsaId, User.Identity.Name);
                if (result == true)
                {
                    return await GetListPulsa();
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
        public async Task<ActionResult> DeleteOperator(MasterOperator model)
        {
            try
            {
                PulsaRepository Repository = new PulsaRepository();
                var result = await Repository.DeleteOperator(model.OperatorId, User.Identity.Name);
                if (result == true)
                {
                    return await GetListOperator(model.PulsaId);
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

        public JsonResult UploadFile()
        {
            string result = "";
            List<string> ListFilename = new List<string>();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                string SystemPath = FilePath.FilePathExcel + Request.Files.AllKeys[0].Split('#')[0] + "/";
                var file = Request.Files[i];

                var fileName = file.FileName; //untuk simpan nama file dgn format baru
                ListFilename.Add(fileName);

                string VirtualPath = SystemPath;
                string TargetPath = System.Web.Hosting.HostingEnvironment.MapPath(VirtualPath);

                if (!System.IO.Directory.Exists(TargetPath))
                {
                    System.IO.Directory.CreateDirectory(TargetPath);
                }

                var path = Path.Combine(Server.MapPath(VirtualPath), fileName);
                try
                {
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}