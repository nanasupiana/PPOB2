using PPOB.Models.Slider;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web;

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
                System.IO.FileStream FS = new System.IO.FileStream(model.Photo, FileMode.Open, FileAccess.Read);
                byte[] img = new byte[FS.Length];
                FS.Read(img, 0, Convert.ToInt32(FS.Length));                          

                SliderRepository Repository = new SliderRepository();
                var result = await Repository.CreateSlider(img, model.Judul,model.DesSingkat,model.DesPanjang);
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

        //public ActionResult GetFileData(string FileName, bool download)
        //{
        //    string ContentType = "application/octet-stream";
        //    byte[] FileData = new byte[0];

        //    SliderRepository Slider = new SliderRepository();
        //    var data = Slider.GetSliderByID(FileName);            
        //    var dataSingle = data;

        //    if (dataSingle != null)

        //    {
        //        //FileData = (byte[])dataSingle[0]["FileData"];
        //        //FileName = dataSingle["FileName"].ToString().Replace(" ", "_");
        //        //ContentType = dataSingle["ContentType"].ToString();
        //    }

        //    HttpContextBase context = this.ControllerContext.HttpContext;
        //    context.Response.Clear();
        //    if (download) context.Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
        //    context.Response.Charset = "";
        //    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    return File(FileData, ContentType);
        //}
    }
}