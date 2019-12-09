using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class StorageService
    {
        public string connection = "DefaultEndpointsProtocol=https;AccountName=infnetassesment;AccountKey=FNvHGLDhYwbabp8AOFCnk816iFd2jMXob2xkA4lIvPrgPTUB2hMdrtfT/2VAlCmlJVEMK1wCgj/ycD19H8uo0Q==;EndpointSuffix=core.windows.net";
        public CloudBlobClient ServiceClient { get; set; }

        public StorageService()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(connection);
            ServiceClient = account.CreateCloudBlobClient();


        }

        public async Task<String> UploadImage(string fileName, Stream fileStream)
        {
            CloudBlobContainer container = ServiceClient.GetContainerReference("images");

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            // Upload the file
            await blockBlob.UploadFromStreamAsync(fileStream);

            return await Task.Factory.StartNew(() =>
            {
                return $"https://infnetassesment.blob.core.windows.net/images/{fileName}";
            });
        }

    }
}
