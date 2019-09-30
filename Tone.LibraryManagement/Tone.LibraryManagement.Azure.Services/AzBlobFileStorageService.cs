using System;
using System.Threading.Tasks;
using Tone.LibraryManagement.Core.Services;

namespace Tone.LibraryManagement.Azure.Services
{
    public class AzBlobFileStorageService : IFileStorageService
    {
        public Task DeleteFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetFileAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveFileAsync()
        {
            throw new NotImplementedException();
        }
    }
}
