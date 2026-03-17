namespace WebsiteBanHang.Utility
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(Microsoft.AspNetCore.Http.IFormFile file, string folderName);
        void DeleteFile(string filePath);
    }
}
