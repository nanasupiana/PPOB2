using PPOB.Models.Slider;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web;
using System.Collections.Generic;
using PPOB.Models;

namespace PPOB.Controllers
{
    public class SliderController : Controller
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
            SliderRepository Repository = new SliderRepository();
            ViewData["ListSlider"] = await Repository.GetSlider();
            return PartialView("_SimpleGrid");
        }

        // POST: Slider/Create
        [HttpPost]
        public async Task<ActionResult> Create(MasterSlider model)
        {
            try
            {                
                //byte[] bytes = System.Convert.FromBase64String(model.Photo);                

                SliderRepository Repository = new SliderRepository();
                string ImageLoc = model.Photo;
                string ImageNewLoc = ImageLoc.Remove(0, 12);
                string ImageName = FilePath.FilePathSlider + ImageNewLoc;
                var result = await Repository.CreateSlider(ImageName, model.Judul,model.DesSingkat,model.DesPanjang,User.Identity.Name);
                if (result == true)
                {
                    return await GetList();
                }
                else
                {
                    return View(result);
                }
            }
            catch ( Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return View(false);
            }
        }

        // POST: Operator/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(MasterSlider model)
        {
            try
            {
                string ImagePath = "E:/Uploads" + "/" + model.Photo;
                byte[] ImageData = System.IO.File.ReadAllBytes(ImagePath);
                SliderRepository Repository = new SliderRepository();
                var result = await Repository.EditSlider(model.ID, ImageData, model.Judul, model.DesSingkat, model.DesPanjang);
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
        public async Task<ActionResult> Delete(MasterSlider model)
        {
            try
            {
                SliderRepository Repository = new SliderRepository();
                var result = await Repository.DeleteSlider(model.ID);
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

        public JsonResult UploadFile()
        {
            string result = "";
            List<string> ListFilename = new List<string>();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                string SystemPath = FilePath.FilePathSlider + "/";
                var file = Request.Files[i];

                var fileName = file.FileName;
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