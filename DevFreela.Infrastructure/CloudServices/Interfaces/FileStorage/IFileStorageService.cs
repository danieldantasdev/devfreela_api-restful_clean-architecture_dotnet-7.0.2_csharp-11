namespace DevFreela.Infrastructure.CloudServices.Interfaces.FileStorage;

public interface IFileStorageService
{
    void UploadFile(byte[] bytes, string fileName);
}