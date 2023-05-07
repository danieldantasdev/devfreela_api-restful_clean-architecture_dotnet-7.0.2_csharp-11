namespace DevFreela.Infrastructure.CloudServices.Interfaces;

public interface IFilesStorageService
{
    void UploadFile(byte[] bytes, string fileName);
}