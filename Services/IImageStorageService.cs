using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureServices.Services
{
    public interface IImageStorageService
    {
        Task<CloudBlobContainer> CreateContainer();

        Task UploadFile(CloudBlobContainer cloudBlobContainer, List<IFormFile> files);

        Task<List<IListBlobItem>> BlobLists(CloudBlobContainer cloudBlobContainer);

        Task DownloadBlob(CloudBlobContainer cloudBlobContainer, string blobName);

        Task DeleteBlob(CloudBlobContainer cloudBlobContainer, string blobName);



    }
}