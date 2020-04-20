using System;
using System.Collections.Generic;
using System.Linq;
using TSIApiWebApp.Core;

namespace TSIApiWebApp.Data
{
    public class SQLUploadedImageData : IUploadedImageData
    {
        private readonly TSIApiWebAppDbContext db;

        public SQLUploadedImageData(TSIApiWebAppDbContext db)
        {
            this.db = db;
        }

        public UploadedImage Add(UploadedImage uploadedImageNew)
        {
            db.UploadedImage.Add(uploadedImageNew);
            return uploadedImageNew;
        }

        public UploadedImage Delete(int imageId)
        {
            UploadedImage uploadedImage = GetUploadedImage(imageId);
            if (uploadedImage != null)
            {
                db.UploadedImage.Remove(uploadedImage);
            }
            return uploadedImage;
        }

        public int GetCount()
        {
            return db.UploadedImage.Count();
        }

        public UploadedImage GetUploadedImage(int imageId)
        {
            return db.UploadedImage.Find(imageId);
        }

        public IEnumerable<UploadedImage> GetUploadedImages(string name)
        {
            var query = from ui in db.UploadedImage
                        where ui.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby ui.Name
                        select ui;
            return query;
        }

        public UploadedImage Update(UploadedImage uploadedImageUpdate)
        {
            var entity = db.UploadedImage.Attach(uploadedImageUpdate);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return uploadedImageUpdate;
        }
    }
}
