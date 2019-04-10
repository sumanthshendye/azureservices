using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServices.Services
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _configuration;

        public QueueService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task CreateQueueAndEnQueue(string message)
        {
            var credentials = new StorageCredentials("hmazurestorage", "wnHqvpEyh5+tI+Zxjs7r9g+BHzwyvRfDYS7N3wqxfWVxuqRhhHBFzzUno5IM6i+hNoOHJ9BLx2PuGNwLSDnBwQ==");

            var cloudStorageAccount = new CloudStorageAccount(credentials, true);

            var cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();

            var cloudQueue = cloudQueueClient.GetQueueReference("hmmyqueue");

            await cloudQueue.CreateIfNotExistsAsync();

            await cloudQueue.AddMessageAsync(new CloudQueueMessage(message));
        }

        public async Task<List<string>> PeekQueueMessage()
        {
            List<CloudQueueMessage> cloudQueueMessages = new List<CloudQueueMessage>();

            List<string> qList = new List<string>();

            var credentials = new StorageCredentials("hmazurestorage", "wnHqvpEyh5+tI+Zxjs7r9g+BHzwyvRfDYS7N3wqxfWVxuqRhhHBFzzUno5IM6i+hNoOHJ9BLx2PuGNwLSDnBwQ==");

            var cloudStorageAccount = new CloudStorageAccount(credentials, true);

            var cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();

            var cloudQueue = cloudQueueClient.GetQueueReference("hmmyqueue");

            await cloudQueue.CreateIfNotExistsAsync();

            cloudQueueMessages = (List<CloudQueueMessage>)await cloudQueue.PeekMessagesAsync(2);

            foreach(var item in cloudQueueMessages)
            {
                if(cloudQueueMessages != null)
                {
                    qList.Add(item.AsString);
                }
            }


            return qList;
        }
    }
}
