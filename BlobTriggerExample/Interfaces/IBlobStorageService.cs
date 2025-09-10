using SharedKernel.Abstractions;

namespace PlaygroundFunction.Interfaces;

public interface IBlobStorageService
{
    Task<Result> UploadBlob(string blobName, byte[] data);
    Task<Result> RetrieveBlob(string blobName);
}
