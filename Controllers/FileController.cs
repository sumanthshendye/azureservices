using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureServices.Controllers
{
    public class FileController : Controller
    {
        private IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult UploadFile()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadFileList(ICollection<IFormFile> formFiles)
        {
            //var formFiless = Request.Form["files"];

            await _fileService.UploadFileAsync(formFiles);

            ViewBag.FileUploaded = "Filese Uploaded Sucessfully";

            return View("UploadFile");
        }
    }
}