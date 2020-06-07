using RembyClipper2.Helpers;
using RembyClipper2.Utils.Meesenger.Uploading.UploadingStrategies;

namespace RembyClipper2.Utils.Uploading.UploadingStrategies
{
    /// <summary>
    /// Describe general interface of the uploading strategy
    /// </summary>
    public interface IUploader
    {
        MediaStoreResponse UploadFile(string path, string filename, string description, string text, string tags, string originalContextUrl = "", string source_url = "", UploadEntityRole role = UploadEntityRole.unknown);
        MediaStoreResponse UploadText(string text, string description, string tags, string originalContextUrl = "", UploadEntityRole role = UploadEntityRole.unknown);
        MediaStoreResponse UploadUrl(string url, string description, string tags, string originalContextUrl, string name, UploadEntityRole role = UploadEntityRole.unknown);
    }
}