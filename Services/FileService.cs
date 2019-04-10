using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServices.Services
{
    public interface IFileService
    {
        Task UploadFileAsync(ICollection<IFormFile> files);
    }



    public class FileService : IFileService
    {
        public async Task UploadFileAsync(ICollection<IFormFile> files)
        {
            var credentials = new StorageCredentials("hmazurestorage", "wnHqvpEyh5+tI+Zxjs7r9g+BHzwyvRfDYS7N3wqxfWVxuqRhhHBFzzUno5IM6i+hNoOHJ9BLx2PuGNwLSDnBwQ==");

            var cloudStorageAccount = new CloudStorageAccount(credentials, true);

            var cloudFileClient = cloudStorageAccount.CreateCloudFileClient();

            CloudFileShare cloudFileShare = cloudFileClient.GetShareReference("hmmyfileshare");

            await cloudFileShare.CreateIfNotExistsAsync();
            
            var cloudRootDirectory = cloudFileShare.GetRootDirectoryReference();

            var cloudRelativeDirectory = cloudRootDirectory.GetDirectoryReference("myfolder");

            await cloudRelativeDirectory.CreateIfNotExistsAsync();

            foreach (IFormFile file in files)
            {
                var fs = file.OpenReadStream();

                var cloudFile = cloudRelativeDirectory.GetFileReference(file.FileName);

                await cloudFile.UploadFromStreamAsync(fs);
            }
        }
    }
}
