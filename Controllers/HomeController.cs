using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureServices.Models;
using AzureServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace AzureServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageStorageService _imageStorageService;

        public HomeController(IImageStorageService imageStorageService)
        {
            _imageStorageService = imageStorageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(List<IFormFile> files)
        {
            try
            {
                CloudBlobContainer cloudBlobContainer = await _imageStorageService.CreateContainer();

                await _imageStorageService.UploadFile(cloudBlobContainer, files);

                ViewBag.Message = "Uploaded Successfully";

                return View("Upload");
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<IActionResult> ProcessBlob()
        {
            CloudBlobContainer cloudBlobContainer = await _imageStorageService.CreateContainer();

            List<IListBlobItem> listBlobItem = await _imageStorageService.BlobLists(cloudBlobContainer);

            ViewBag.BlobLists = listBlobItem;

            return View();
        }

        //[HttpPost]
        public IActionResult Download()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DownloadBlob()
        {
            var blobname = Request.Form["container"].ToString();

            CloudBlobContainer cloudBlobContainer = await _imageStorageService.CreateContainer();

           await _imageStorageService.DownloadBlob(cloudBlobContainer, blobname);

            ViewBag.DownloadSatus = "Downloaded Successfully";

            return View("Download");
        }

        public async Task<IActionResult> DeleteBlob()
        {
            CloudBlobContainer cloudBlobContainer = await _imageStorageService.CreateContainer();

            await _imageStorageService.DeleteBlob(cloudBlobContainer, "");

            ViewBag.DeleteBlob = "Deleted Successfully";

            return View("ProcessBlob");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
