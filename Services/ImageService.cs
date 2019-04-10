using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServices.Services
{
    public class ImageService : IImageStorageService
    {
        private readonly IConfiguration _configuration;

        public ImageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<CloudBlobContainer> CreateContainer()
        {
            var credentials = new StorageCredentials("hmazurestorage", "wnHqvpEyh5+tI+Zxjs7r9g+BHzwyvRfDYS7N3wqxfWVxuqRhhHBFzzUno5IM6i+hNoOHJ9BLx2PuGNwLSDnBwQ==");

            var cloudStorageAccount = new CloudStorageAccount(credentials, true);

            var cloudblobclient = cloudStorageAccount.CreateCloudBlobClient();

            var container = cloudblobclient.GetContainerReference("imagecontainer");

            await container.CreateIfNotExistsAsync();

            return container;
        }

        public async Task UploadFile(CloudBlobContainer cloudBlobContainer, List<IFormFile> files)
        {            
            foreach (IFormFile file in files)
            {
                var fs = file.OpenReadStream();
                
                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(file.FileName);

                cloudBlockBlob.Properties.ContentType = file.ContentType;

                await cloudBlockBlob.UploadFromStreamAsync(fs);
            }
        }

        public async Task<List<IListBlobItem>> BlobLists(CloudBlobContainer cloudBlobContainer)
        {
            List<IListBlobItem> blobs = new List<IListBlobItem>();

            BlobResultSegment blobResultSegment = await cloudBlobContainer.ListBlobsSegmentedAsync(null);

            blobs = blobResultSegment.Results.ToList();

            return blobs;
        }

        public async Task DownloadBlob(CloudBlobContainer cloudBlobContainer,string blobName)
        {
            List<IListBlobItem> blobs = new List<IListBlobItem>();

            BlobResultSegment blobResultSegment = await cloudBlobContainer.ListBlobsSegmentedAsync(null);

            blobs = blobResultSegment.Results.ToList();

            foreach(var item in blobs)
            {
                CloudBlockBlob newItem = (CloudBlockBlob)item;

                CloudBlockBlob cloudBlob = cloudBlobContainer.GetBlockBlobReference(newItem.Name);

                DirectoryInfo directoryInfo = Directory.CreateDirectory(@"C:\Users\Sumanth.k\Desktop\Downloads");

                await cloudBlob.DownloadToFileAsync(@"C:\Users\Sumanth.k\Desktop\Downloads\"+newItem.Name, FileMode.Create);
            }
        }

        public async Task DeleteBlob(CloudBlobContainer cloudBlobContainer, string blobName)
        {
            var blockblob = cloudBlobContainer.GetBlockBlobReference("");

            await blockblob.DeleteIfExistsAsync();
        }
    }
}
