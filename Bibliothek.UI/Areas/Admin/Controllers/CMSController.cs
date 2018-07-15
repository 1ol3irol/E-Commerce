using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Admin.Models.DTO;
using Bibliothek.UI.Attributes;
using Bibliothek.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Admin.Controllers
{
    public class CMSController : Controller
    {
        SliderService _sliderService;
        public CMSController()
        {
            _sliderService = new SliderService();
        }

        [CustomAuthorize(Role.Admin)]
        public ActionResult SliderList()
        {
            List<Slider> model = _sliderService.GetActive();
            return View(model);
        }

        public ActionResult SliderAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderAdd(Slider data, HttpPostedFileBase Image)
        {
            data.SliderPath = ImageUploader.UploadSingleImage("/Sliders/", Image);

            if (data.SliderPath == "0" || data.SliderPath == "1" || data.SliderPath == "2")
                data.SliderPath = "Content/Images/Web/Home/product.jpg";

            _sliderService.Add(data);
            
            return Redirect("/Admin/CMS/SliderList");
        }

        public ActionResult SliderUpdate(Guid id)
        {
            Slider slider = _sliderService.GetByID(id);
            SliderDTO model = new SliderDTO();
            model.ID = slider.ID;
            model.Queue = slider.Queue;
            return View(model);
        }

        [HttpPost]
        public ActionResult SliderUpdate(SliderDTO data)
        {
            Slider slider = _sliderService.GetByID(data.ID);
            slider.Queue = data.Queue;
            _sliderService.Update(slider);
            return Redirect("/Admin/CMS/SliderList");
        }



        public RedirectResult SliderDelete(Guid id)
        {
            _sliderService.Remove(id);
            return Redirect("/Admin/CMS/SliderList");
        }
    }
}