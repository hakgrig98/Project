using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_DAL.UnitOfWork;
using Project_Processor.Processors;
using Project_Web.Models;

namespace Project_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataProcessor _dataProcessor;
        public HomeController(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var adverts=_dataProcessor.GetAdverts();
            return View(adverts);
        }

        [HttpGet]
        public IActionResult AddAdvert()
        {
            return View();
        }

        public JsonResult AddAdvert([FromBody]AdvertModel advertModel)
        {
            string response = string.Empty;
            if (ModelState.IsValid)
            {
                response = _dataProcessor.AddAdvert(advertModel.Number, advertModel.CreatedDate, advertModel.UserId, advertModel.Rating);
            }
            else
            {
                response = "model is invalid";
            }
            return Json(response);
        }

        public JsonResult GetUsers()
        {
            var users=_dataProcessor.GetUsers();
            return Json(users);
        }
    }
}
