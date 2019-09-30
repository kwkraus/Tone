using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;
using Tone.LibraryManagement.Azure.Services.Options;
using Tone.LibraryManagement.Core.Services;

namespace Tone.LibraryManagement.Azure.Services
{
    public class AzureStorageService : IStorageService
    {
        // Parse the connection string and return a reference to the storage account.
        private CloudStorageAccount _storageAccount;

        public AzureStorageService(IOptionsMonitor<AzureStorageOptions> options)
        {
            CloudStorageAccount.UseV1MD5 = false;
            _storageAccount = CloudStorageAccount.Parse(options.CurrentValue.ConnectionString);
        }

        public async Task<bool> DeleteFileIfExistsAsync(string blobUrl)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            try
            {
                var x = await blobClient.GetBlobReferenceFromServerAsync(new Uri(blobUrl));
                return await x.DeleteIfExistsAsync();
            }
            catch(Exception ex)
            {
                //log reason why it failed
                return false;
            }
        }

        public string GenerateSASToken(Uri docUri, string containerName)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            BlobContainerPermissions permissions = new BlobContainerPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Off;
            permissions.SharedAccessPolicies.Clear();
            permissions.SharedAccessPolicies.Add("twominutepolicy", new SharedAccessBlobPolicy());
            container.SetPermissionsAsync(permissions);

            SharedAccessBlobPolicy sharedPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-1),
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(2),
                Permissions = SharedAccessBlobPermissions.Read
            };

            CloudBlockBlob blob = container.GetBlockBlobReference(docUri.ToString());

            return blob.GetSharedAccessSignature(sharedPolicy, "twominutepolicy");
        }

        public async Task<Stream> GetFileAsStreamAsync(string fileReference, string location)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(location);

            MemoryStream outputStream = new MemoryStream();
            await container.GetBlobReference(fileReference).DownloadToStreamAsync(outputStream);
            return outputStream;
        }


        public async Task<string> UploadFileStreamAsync(Stream fileContents, params string[] list)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(list[0]);

            // Create the container if it doesn't already exist.
            await container.CreateIfNotExistsAsync();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(list[1]);
            await blockBlob.UploadFromStreamAsync(fileContents);

            return blockBlob.Uri.ToString();
        }
    }
}
