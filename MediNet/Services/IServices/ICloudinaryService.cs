using CloudinaryDotNet.Actions;

namespace MediNet.Services.IServices
{
    public interface ICloudinaryService
    {
        Task<string> UploadImage(IFormFile file);
        Task<DelResResult> RemoveImage(string imageUrl);
    }
}
