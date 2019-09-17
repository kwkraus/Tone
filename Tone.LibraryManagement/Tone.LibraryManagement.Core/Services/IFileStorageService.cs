using System.Threading.Tasks;

namespace Tone.LibraryManagement.Core.Services
{
    public interface IFileStorageService
    {
        Task SaveFileAsync();
        Task DeleteFileAsync();
        Task<byte[]> GetFileAsync();
    }
}
