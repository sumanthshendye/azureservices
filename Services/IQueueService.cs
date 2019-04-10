using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServices.Services
{
    public interface IQueueService
    {
        Task CreateQueueAndEnQueue(string message);

        Task<List<string>> PeekQueueMessage();
    }
}
