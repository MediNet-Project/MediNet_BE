using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using MediNet.Services.IServices;

namespace MediNet.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(string cloudName, string apiKey, string apiSecret)
        {
            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public async Task<DelResResult> RemoveImage(string imageUrl)
        {
            var uri = new Uri(imageUrl);
            var publicId = Path.GetFileNameWithoutExtension(uri.AbsolutePath);

            DelResParams deleteParams = new()
            {
                PublicIds = new List<string>() { "MediNet/" + publicId }
            };

            return _cloudinary.DeleteResources(deleteParams);
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "MediNet",
            };

            ImageUploadResult uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }
    }
}
