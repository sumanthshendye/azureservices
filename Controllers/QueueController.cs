using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AzureServices.Controllers
{
    public class QueueController : Controller
    {
        private IQueueService _queueService;

        public QueueController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public IActionResult Queue()
        {
            return View();
        }

        [Route("Queue")]
        public IActionResult EnQueue()
        {
            string message = Request.Form["queue"].ToString();

            _queueService.CreateQueueAndEnQueue(message);

            ViewBag.InserMessage = "Message Inserted";

            return View("Queue");
        }

        public async Task<IActionResult> PeekQueue()
        {
            List<string> cloudQueueMessages = await _queueService.PeekQueueMessage();

            ViewBag.CloudQueueMessages = cloudQueueMessages;

            return View();
        }


    }
}