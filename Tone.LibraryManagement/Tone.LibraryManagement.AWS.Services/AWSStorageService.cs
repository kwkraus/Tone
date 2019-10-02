using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using Tone.LibraryManagement.Azure.Services.Options;
using Tone.LibraryManagement.Core.Services;

namespace Tone.LibraryManagement.AWS.Services
{
    public class AWSStorageService : IStorageService
    {
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 _s3Client;

        public AWSStorageService(IAmazonS3 s3Client, IOptionsMonitor<AWSStorageOptions> options)
        {
            _s3Client = s3Client;
        }

        public Task<bool> DeleteFileIfExistsAsync(string fileReference)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetFileAsStreamAsync(string fileReference, string location)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFileStreamAsync(Stream fileContents, params string[] list)
        {
            try
            {
                using var fileTransferUtility = new TransferUtility(_s3Client);
                await fileTransferUtility.UploadAsync(fileContents, list[0], list[1]);
                return string.Empty;
            }
            catch (AmazonS3Exception e)
            {
                throw new ApplicationException($"Error encountered on server. Message:'{e.Message}' when writing an object", e);
            }
        }
    }
}
