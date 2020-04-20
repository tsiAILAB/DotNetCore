using System.Collections.Generic;
using System.Text;
using TSIApiWebApp.Core;

namespace TSIApiWebApp.Data
{
    public interface IUploadedImageData
    {
        UploadedImage Add(UploadedImage uploadedImageNew);
        UploadedImage Update(UploadedImage uploadedImageUpdate);
        UploadedImage Delete(int imageId);
        int GetCount();
        IEnumerable<UploadedImage> GetUploadedImages(string name);
        UploadedImage GetUploadedImage(int imageId);
    }
}
