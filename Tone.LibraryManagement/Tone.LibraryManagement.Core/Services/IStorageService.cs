using System.IO;
using System.Threading.Tasks;

namespace Tone.LibraryManagement.Core.Services
{
    public interface IStorageService
    {
        Task<Stream> GetFileAsStreamAsync(string fileReference, string location);
        Task<bool> DeleteFileIfExistsAsync(string fileReference);
        Task<string> UploadFileStreamAsync(Stream fileContents, params string[] list);
    }
}