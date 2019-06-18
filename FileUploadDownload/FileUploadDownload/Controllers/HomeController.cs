using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileUploadDownload.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FileUploadDownload.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _enviroment;
        public HomeController(IHostingEnvironment enviroment)
        {
            _enviroment = enviroment;
        }
        public IActionResult Index()
        {
            return View();
        }

     [HttpPost]
     public async Task<IActionResult> Upload(FileUploadDownloadViewModel model)
        {
            var file = model.File;
            if(file.Length>0)
            {
                string path = Path.Combine(_enviroment.WebRootPath, "images");
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                model.destination = $"/images/{file.FileName}";
                model.extension = Path.GetExtension(file.FileName).Substring(1);
                return Ok(model);
            }
            return BadRequest();
        }
     
        
    }
}
